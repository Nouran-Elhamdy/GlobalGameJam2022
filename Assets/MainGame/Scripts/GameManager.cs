using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] players;
    public static GameManager Instance;
    [SerializeField] SpriteRenderer[] lamps;
    private void Start()
    {
        Instance = this;
    }
    public static void ResetLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
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
        if (DetectDoorIfOpenedAtSameTime())
        {
            ChangeLampsColor();
        }
    }
}
