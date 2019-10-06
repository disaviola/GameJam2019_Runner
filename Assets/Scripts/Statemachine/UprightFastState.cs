using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Player/UprightFastState")]
public class UprightFastState : BaseState
{
    [SerializeField] private float playerWidth = 0;
    [SerializeField] private float playerHeight = 4;

    bool reseted = false;

    public override void Enter()
    {

        //owner.transform.localScale = new Vector3(1, 1, 1);
        //owner.transform.localScale += new Vector3(0, playerHeight, 0);
        //SFXmanager.SFXIntsance.PlaySuck();
        owner.movementHandler.SetSpeedMode(true, originalSpeed);
        owner.movementHandler.SetRocketMode(2);



    }

    public override void HandleFixedUpdate()
    {
        if(!reseted && owner.transform.localScale.x > 1)
        
        {
            owner.transform.localScale -= new Vector3(3.5f, 0, 0) * 7 * Time.deltaTime;
        }
        if(owner.transform.localScale == new Vector3(1, 1, 1))
        {
            reseted = true;
        }
        if(reseted && owner.transform.localScale.y < 4)
        {
            owner.transform.localScale += new Vector3(0, playerHeight, 0) * 7 * Time.deltaTime;
        }
        owner.movementHandler.SetMovement();
    }

    public override void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            owner.Transition<BaseState>();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            owner.Transition<FastState>();
        }
    }

    public override void Exit()
    {
        reseted = false;
    }

}
