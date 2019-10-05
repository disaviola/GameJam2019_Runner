using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/BaseState")]
public class BaseState : State
{
    protected Player owner;
    protected PlayerMovement movementHandler;
    private Vector3 originalScale = new Vector3(1, 1, 1);
    [SerializeField] protected float originalSpeed = 5f; 

    public override void Enter()
    {
        Debug.Log("Base");
        owner.transform.localScale = originalScale;
        movementHandler = owner.movementHandler;
        movementHandler.SetSpeedMode(false, originalSpeed);
        
    }

    public override void Initialize(StateMachine owner)
    {
        
        this.owner = (Player)owner;
    }

    public override void HandleFixedUpdate()
    {
        
        movementHandler.SetMovement();
        base.HandleFixedUpdate();
    }

    public override void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            owner.Transition<FastState>();
        }
    }

}
