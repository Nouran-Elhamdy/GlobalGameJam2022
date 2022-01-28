using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBase : MonoBehaviour
{
    public static PlayerControllerBase Instance;
    [SerializeField] float stepForward;
    [SerializeField] float stepBackward;
    [SerializeField] float jumpHeight;
    [SerializeField] float speed;
    [SerializeField] Vector3 playerPosition;
    private void Start()
    {
        Instance = this;
        playerPosition = GetComponent<Rigidbody>().position;
    }
    public void MoveRight()
    {
        Debug.Log("Move Right!");
        Vector3 movePos = new Vector3(stepForward * Time.deltaTime * speed ,0,0);
        GetComponent<Rigidbody>().position += movePos;
    }
    public void MoveLeft()
    {
        Debug.Log("Move Left!");
        Vector3 movePos = new Vector3(stepForward * Time.deltaTime * speed, 0, 0);
        GetComponent<Rigidbody>().position += movePos;
    }
    public void MoveUp()
    {
        Debug.Log("Move Up!");
    }
    public void MoveDown()
    {
        Debug.Log("Move Down!");
    }
    public void Jump()
    {
        Debug.Log("Jump!");
        GroundPlayer();
        GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
    }
    public void Push()
    {
        Debug.Log("Push!");
        GetComponent<Rigidbody>().AddForce(Vector3.right * 100);
    }
    //public static void Teleport()
    //{
    //    Debug.Log("Teleport!");
    //}
    //public static void OpenDoor()
    //{
    //    Debug.Log("Open Door!");
    //}
    //public static void Attack()
    //{
    //    Debug.Log("Attack!");
    //}

    //public static void Die()
    //{
    //    Debug.Log("Die!");
    //}

    //public static void SwitchPlayer()
    //{
    //    Debug.Log("Switch Player!");
    //}
    //public static void SwitchPosition()
    //{
    //    Debug.Log("Switch Positions!");
    //}
    public void GroundPlayer()
    {
        if (GetComponent<Rigidbody>().position.y > jumpHeight)
        {
            Debug.Log("Ground Player");
            Vector3 movePos = new Vector3(0, stepForward * Time.deltaTime * speed, 0);
            GetComponent<Rigidbody>().position -= movePos;
        }
    }

    private void Update()
    {
       // GroundPlayer();
    }
}
