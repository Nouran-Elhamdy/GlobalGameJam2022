using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public string playerState;
    bool isBlueActive;
    bool isRedActive = true;
    public static PlayerState Instance;

    private void Start()
    {
        Instance = this;
    }

    public void SwitchPlayer()
    {
        isBlueActive = !isRedActive;
        if (isBlueActive)
        {
            playerState = "BluePlayer";
            isRedActive = true;
        }
        else
        {
            playerState = "RedPlayer";
            isRedActive = false;
        }

        Debug.Log("Bool = " + isBlueActive);
    }
    private void Update()
    {
        Debug.Log("playerState = " + playerState);
    }
}
