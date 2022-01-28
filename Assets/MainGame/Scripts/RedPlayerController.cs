using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerController : PlayerControllerBase
{
    public static new RedPlayerController Instance;
    [SerializeField] GameObject[] objs;
    [SerializeField] GameObject portalPos;
    [SerializeField] GameObject detectionPoint;
    public float fallingThreshold = -10f;
    RaycastHit hit;
    public bool isFalling { get; private set; }

    private void Start()
    {
        Instance = this;
    }
    public override void MoveLeft()
    {
        Vector3 movePos = new Vector3(stepForward * Time.deltaTime * speed, 0, 0);
        GetComponent<Rigidbody>().position -= movePos;
    }
    public override void Jump()
    {
        GroundPlayer();
        GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
    }
    public override void GroundPlayer()
    {
        if (GetComponent<Rigidbody>().position.y > jumpHeight)
        {
            Vector3 movePos = new Vector3(0, stepForward * Time.deltaTime * speed, 0);
            GetComponent<Rigidbody>().position -= movePos;
        }
    }
    public override void OpenDoor()
    {
        OnOpenDoor.Raise();
    }
    public override void Teleport()
    {
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].GetComponent<BoxCollider>().isTrigger = true;
            if (objs[i].GetComponent<Rigidbody>())
            objs[i].GetComponent<Rigidbody>().useGravity = false;
        }
        StartCoroutine(DisappearAndReappear());
       
        IEnumerator DisappearAndReappear()
        {
            yield return new WaitForSeconds(0.7f);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(1.0f);
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().position = portalPos.transform.position;
            gameObject.GetComponent<MeshRenderer>().enabled = true;

            while (GetComponent<Rigidbody>().position.y < 1.4f)
            {
                Vector3 movePos = new Vector3(0, stepForward * Time.deltaTime * speed, 0);
                GetComponent<Rigidbody>().position += movePos;
            }
            for (int i = 0; i < objs.Length; i++)
            {
                objs[i].GetComponent<BoxCollider>().isTrigger = false;
                if (objs[i].GetComponent<Rigidbody>())
                    objs[i].GetComponent<Rigidbody>().useGravity = true;
            }
            GetComponent<Rigidbody>().useGravity = true;
        }
    }

    public override void Die()
    {
        OnPlayerDies.Raise();
    }
    private void Update()
    {
        if (GetComponent<Rigidbody>().velocity.y < fallingThreshold)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }

        if (isFalling)
        {
            Die();
        }
        DetectPlayer();
    }

    public override void DetectPlayer()
    {
        if (Physics.Raycast(detectionPoint.transform.position, detectionPoint.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(detectionPoint.transform.position, detectionPoint.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if(hit.collider.CompareTag("BluePlayer"))
            {
                GetComponent<MeshRenderer>().material.color = Color.white;
                hit.collider.GetComponent<MeshRenderer>().material.color = Color.white;
                Invoke("Die",2);
            }
        }
        else
        {
            Debug.DrawRay(detectionPoint.transform.position, detectionPoint.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
    }
}
