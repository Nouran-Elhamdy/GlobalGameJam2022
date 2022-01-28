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
    [SerializeField] protected SO.Events.EventSO OnPlayerDies;


    private void Start()
    {
        Instance = this;
        playerPosition = GetComponent<Rigidbody>().position;
    }
    public virtual void MoveRight()
    {
    }
    public virtual void MoveLeft()
    {
    }
    public virtual void MoveUp()
    {
    }
    public virtual void MoveDown()
    {
    }
    public virtual void Jump()
    {
    }
    public virtual void Push()
    {
    }
    public virtual void Teleport()
    {
    }
    public virtual void OpenDoor()
    {
    }
    public virtual void Attack()
    {
    }

    public virtual void Die()
    {
        Debug.Log("Die!");
    }

    
    public void SwitchPosition()
    {
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
