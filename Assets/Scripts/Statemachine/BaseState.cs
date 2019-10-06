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

        //owner.transform.localScale = originalScale;
        movementHandler = owner.movementHandler;
        movementHandler.SetSpeedMode(false, originalSpeed);
        owner.movementHandler.SetRocketMode(0);
    }

    public override void Initialize(StateMachine owner)
    {
        
        this.owner = (Player)owner;
    }

    public override void HandleFixedUpdate()
    {
        if(owner.transform.localScale.x > 1)
        {
            owner.transform.localScale -= new Vector3(3.5f, 0, 0) * 7 * Time.deltaTime;
        }
        if(owner.transform.localScale.y > 1)
        {
            owner.transform.localScale -= new Vector3(0, 4, 0) * 7 * Time.deltaTime;
        }
        
        movementHandler.SetMovement();
        base.HandleFixedUpdate();
    }

    public override void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            owner.Transition<FastState>();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            owner.Transition<UprightFastState>();
        }
    }

}
