using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] SpriteRenderer lamp;
 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("UpBox") || collision.gameObject.CompareTag("DownBox"))
            BluePlayerController.Instance.Push();

        if (collision.gameObject.CompareTag("Door"))
        {
            Debug.Log("Open Door");
            lamp.color = Color.yellow;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            Debug.Log("leave Door");
            lamp.color = Color.red;
        }
    }

}
