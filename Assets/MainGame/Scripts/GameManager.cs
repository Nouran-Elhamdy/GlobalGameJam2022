using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] players;
    [SerializeField] GameObject blueDialoguePanel;
    [SerializeField] GameObject RedDialoguePanel;
    [SerializeField] GameObject blueHintForSwitch;
    public static GameManager Instance;
    [SerializeField] SpriteRenderer[] lamps;
    [SerializeField] GameObject blueText;
    [SerializeField] GameObject RedText;

    private void Start()
    {
        Instance = this;

        if (string.IsNullOrEmpty(PlayerPrefs.GetString("BlueDialogue")))
            StartCoroutine(BlueDialogue());
    }
    public static void ResetLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public bool DetectDoorIfOpenedAtSameTime()
    {
        if (players[0].GetComponent<PlayerCollision>().isOpenningDoor &&
            players[1].GetComponent<PlayerCollision>().isOpenningDoor)
            return true;

        else
            return false;
    }
    public void ChangeLampsColor()
    {
        for (int i = 0; i < lamps.Length; i++)
        {
            lamps[i].color = Color.green;
        }
    }
    private void Update()
    {
        //if (DetectDoorIfOpenedAtSameTime())
        //{
        //    ChangeLampsColor();
        //}
    }


    IEnumerator BlueDialogue()
    {
        PlayerPrefs.SetString("BlueDialogue", "Set");
        yield return new WaitForSeconds(1.0f);
        blueDialoguePanel.SetActive(true);
        yield return new WaitForSeconds(6.5f);
        blueDialoguePanel.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        blueHintForSwitch.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        blueHintForSwitch.SetActive(false);
    }

    public void StartBlueDialogue()
    {
        StartCoroutine(RedDialogue());
        IEnumerator RedDialogue()
        {
            yield return new WaitForSeconds(1.0f);
            RedDialoguePanel.SetActive(true);
            yield return new WaitForSeconds(6.5f);
            RedDialoguePanel.SetActive(false);
        }
    }

}
