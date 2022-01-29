using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    int currentJump;
    bool canJump = true;
    int maxJumps = 1;
    [SerializeField] PlayerCollision redPlayerCollision;
    [SerializeField] SO.Events.EventSO OnOpenBothDoors;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject pausePanel;
    void Update()
    {
        HandlePlayerInputs();
    }

    public void HandlePlayerInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            if (PlayerState.Instance.playerState == "BluePlayer")
            {
                BluePlayerController.Instance.Jump();
            }
            if (PlayerState.Instance.playerState == "RedPlayer")
            {
                RedPlayerController.Instance.Jump();
            }
            currentJump++;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (PlayerState.Instance.playerState == "RedPlayer")
                RedPlayerController.Instance.MoveLeft();
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (PlayerState.Instance.playerState == "BluePlayer")
                BluePlayerController.Instance.MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (PlayerState.Instance.playerState == "RedPlayer")
                RedPlayerController.Instance.MoveUp();
        }
        if (redPlayerCollision.OnPortal && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            if (PlayerState.Instance.playerState == "RedPlayer")
                RedPlayerController.Instance.Teleport();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            PlayerState.Instance.SwitchPlayer();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            if(GameManager.Instance.DetectDoorIfOpenedAtSameTime())
            {
                winPanel.SetActive(true);
                return;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
        }
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
