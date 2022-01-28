using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerController : PlayerControllerBase
{
    public static new RedPlayerController Instance;

    private void Start()
    {
        Instance = this;
    }
    public override void MoveLeft()
    {
        base.MoveLeft();
        Debug.Log("Move Red Right!");
        Vector3 movePos = new Vector3(stepForward * Time.deltaTime * speed, 0, 0);
        GetComponent<Rigidbody>().position += movePos;
    }
    public override void Jump()
    {
        Debug.Log("Red Jump!");
        GroundPlayer();
        GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
    }
    public override void GroundPlayer()
    {
        if (GetComponent<Rigidbody>().position.y > jumpHeight)
        {
            Debug.Log("Ground Red Player");
            Vector3 movePos = new Vector3(0, stepForward * Time.deltaTime * speed, 0);
            GetComponent<Rigidbody>().position -= movePos;
        }
    }
}
