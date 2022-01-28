using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] SpriteRenderer lamp;

    public bool OnPortal;

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("BluePlayer") && (collision.gameObject.CompareTag("UpBox") || collision.gameObject.CompareTag("DownBox")))
            BluePlayerController.Instance.Push();

        if (collision.gameObject.CompareTag("Door"))
        {
            Debug.Log("Open Door");
            lamp.color = Color.yellow;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (gameObject.CompareTag("RedPlayer") && other.gameObject.CompareTag("Portal"))
        {
            OnPortal = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (gameObject.CompareTag("RedPlayer") && other.gameObject.CompareTag("Portal"))
        {
            OnPortal = false;
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
