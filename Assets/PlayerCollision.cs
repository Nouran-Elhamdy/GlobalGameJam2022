using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("UpBox") || collision.gameObject.CompareTag("DownBox"))
            PlayerControllerBase.Instance.Push();

        if (collision.gameObject.CompareTag("Ground"))
        {

        }

    }

    
 
}
