using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public string playerState;
    bool isBlueActive;
    bool isRedActive = true;
    [SerializeField] GameObject blueArrow; 
    [SerializeField] GameObject redArrow; 
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
            blueArrow.SetActive(true);
            redArrow.SetActive(false);
        }
        else
        {
            playerState = "RedPlayer";
            isRedActive = false;
            blueArrow.SetActive(false);
            redArrow.SetActive(true);
            if(playerState == "RedPlayer" && string.IsNullOrEmpty(PlayerPrefs.GetString("RedDialogue")))
            {
                GameManager.Instance.StartBlueDialogue();
                PlayerPrefs.SetString("RedDialogue", "Set");
            }
        }
    }
}
