using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/BaseState")]
public class BaseState : State
{
    protected Player owner;
    protected PlayerMovement movementHandler;

    public override void Enter()
    {
        movementHandler = owner.movementHandler;
        movementHandler.SetSpeedMode(false);
        
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
