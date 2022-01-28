using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    int currentJump;
    bool canJump = true;
    int maxJumps = 1;
    void Update()
    {
        HandlePlayerInputs();
    }

    public void HandlePlayerInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            PlayerControllerBase.Instance.Jump();
            currentJump++;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PlayerControllerBase.Instance.MoveLeft();
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            PlayerControllerBase.Instance.MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerControllerBase.Instance.MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlayerControllerBase.Instance.MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            PlayerControllerBase.Instance.Push();
        }
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    PlayerControllerBase.SwitchPosition();
        //}
        //if (Input.GetMouseButtonDown(0))
        //{
        //    PlayerControllerBase.SwitchPlayer();
        //}
        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    PlayerControllerBase.OpenDoor();
        //}
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    //Reset or Exit Game
        //}
        if (currentJump == maxJumps)
        {
            StartCoroutine(CoolDown());
        }
    
    }
    IEnumerator CoolDown()
    {
        currentJump = 0;
        canJump = false;
        yield return new WaitForSeconds(1);
        canJump = true;
    }
}