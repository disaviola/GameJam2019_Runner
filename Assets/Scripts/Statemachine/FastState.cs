using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Player/FastState")]
public class FastState : BaseState
{
    [SerializeField] private float playerWidth = 3.5f;
    public override void Enter()
    {
        owner.transform.localScale += new Vector3(playerWidth, 0, 0);
        owner.movementHandler.SetSpeedMode(true);
        base.Enter();
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
            owner.Transition<UprightFastState>();
        }

    }
}
