using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] SpriteRenderer lamp;

    public bool OnPortal;
    public bool isOpenningDoor;
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("BluePlayer") && (collision.gameObject.CompareTag("UpBox") || collision.gameObject.CompareTag("DownBox")))
            BluePlayerController.Instance.Push();

        if (collision.gameObject.CompareTag("Door") && !isOpenningDoor)
        {
            lamp.color = Color.yellow;
            isOpenningDoor = true;
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

}
