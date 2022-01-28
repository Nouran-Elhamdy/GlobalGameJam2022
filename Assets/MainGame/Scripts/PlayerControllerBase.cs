using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBase : MonoBehaviour
{
    public static PlayerControllerBase Instance;
    [SerializeField] protected float stepForward;
    [SerializeField] protected float stepBackward;
    [SerializeField] protected float jumpHeight;
    [SerializeField] protected float speed;
    [SerializeField] protected Vector3 playerPosition;
    [SerializeField] protected SO.Events.EventSO OnOpenDoor;

    private void Start()
    {
        Instance = this;
        playerPosition = GetComponent<Rigidbody>().position;
    }
    public virtual void MoveRight()
    {
        Debug.Log("Move Right!");
    }
    public virtual void MoveLeft()
    {
        Debug.Log("Move Left!");
    }
    public virtual void MoveUp()
    {
        Debug.Log("Move Up!");
    }
    public virtual void MoveDown()
    {
        Debug.Log("Move Down!");
    }
    public virtual void Jump()
    {
    }
    public virtual void Push()
    {
        Debug.Log("Push!");
    }
    public virtual void Teleport()
    {
        Debug.Log("Teleport!");
    }
    public virtual void OpenDoor()
    {
        Debug.Log("Open Door!");
        OnOpenDoor.Raise();
    }
    public virtual void Attack()
    {
        Debug.Log("Attack!");
    }

    public virtual void Die()
    {
        Debug.Log("Die!");
    }

    
    public void SwitchPosition()
    {
        Debug.Log("Switch Positions!");
    }
    public virtual void GroundPlayer()
    {
        
    }
    public void DetectCurrentPlayer()
    {

    }
    private void Update()
    {
    }
}
