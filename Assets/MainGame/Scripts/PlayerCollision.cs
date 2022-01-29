using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] SpriteRenderer lamp;
    [SerializeField] GameObject hintTeleport;
    [SerializeField] GameObject hintOpenB;
    [SerializeField] GameObject hintOpenR;
    [SerializeField] GameObject hintJump;

    public bool OnPortal;
    public bool isOpenningDoor;
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("BluePlayer") && (collision.gameObject.CompareTag("UpBox") || collision.gameObject.CompareTag("DownBox")))
        {
            BluePlayerController.Instance.Push();
            ShowHint(hintJump);
        }

        if (PlayerState.Instance.playerState == "BluePlayer" && collision.gameObject.CompareTag("Door") && !isOpenningDoor)
        {
            lamp.color = Color.green;
            isOpenningDoor = true;
            ShowHint(hintOpenB);
        }
        if (PlayerState.Instance.playerState == "RedPlayer" && collision.gameObject.CompareTag("RedDoor") && !isOpenningDoor)
        {
            lamp.color = Color.green;
            isOpenningDoor = true;
            ShowHint(hintOpenR);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (gameObject.CompareTag("RedPlayer") && other.gameObject.CompareTag("Portal"))
        {
            OnPortal = true;
            ShowHint(hintTeleport);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (gameObject.CompareTag("RedPlayer") && other.gameObject.CompareTag("Portal"))
        {
            OnPortal = false;
        }
    }

    public void ShowHint(GameObject obj)
    {
        if(obj)
        {
            obj.SetActive(true);
            StartCoroutine(Delay());
            IEnumerator Delay()
            {
                yield return new WaitForSeconds(4.0f);
                Destroy(obj);
            }
        }
    }
}
