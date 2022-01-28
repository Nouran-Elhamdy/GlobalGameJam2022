using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayerController : PlayerControllerBase
{
    public static new BluePlayerController Instance;

    private void Start()
    {
        Instance = this;
    }
    public override void MoveRight()
    {
        base.MoveRight();
        Debug.Log("Move Blue Right!");
        Vector3 movePos = new Vector3(stepForward * Time.deltaTime * speed, 0, 0);
        GetComponent<Rigidbody>().position += movePos;
    }
    public override void Jump()
    {
        Debug.Log("Blue Jump!");
        GroundPlayer();
        GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
    }
    public override void GroundPlayer()
    {
        if (GetComponent<Rigidbody>().position.y > jumpHeight)
        {
            Debug.Log("Ground Blue Player");
            Vector3 movePos = new Vector3(0, stepForward * Time.deltaTime * speed, 0);
            GetComponent<Rigidbody>().position -= movePos;
        }
    }
    public override void Push()
    {
        base.Push();
        GetComponent<Rigidbody>().AddForce(Vector3.right * 100);
        Debug.Log("Blue Push!");
    }
    public override void OpenDoor()
    {
        base.OpenDoor();
        Debug.Log("Blue Opens Door!");
        OnOpenDoor.Raise();
    }
}
