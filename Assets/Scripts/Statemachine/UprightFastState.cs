using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Player/UprightFastState")]
public class UprightFastState : BaseState
{
    public override void Enter()
    {
        float yRotation = 90.0f;
        owner.transform.eulerAngles = new Vector3(owner.transform.eulerAngles.x, yRotation, owner.transform.eulerAngles.z);
    }

    public override void HandleFixedUpdate()
    {

        owner.movementHandler.SetMovement();
    }

    public override void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            owner.Transition<BaseState>();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            owner.Transition<FastState>();
        }
    }
}
