using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Player/UprightFastState")]
public class UprightFastState : BaseState
{
    [SerializeField] private float playerWidth = 0;
    [SerializeField] private float playerHeight = 4;

    public override void Enter()
    {
        Debug.Log("UprightFast");
        owner.transform.localScale = new Vector3(1, 1, 1);
        owner.transform.localScale += new Vector3(0, playerHeight, 0);
    }

    public override void HandleFixedUpdate()
    {

        owner.movementHandler.SetMovement();
    }

    public override void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            owner.Transition<BaseState>();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            owner.Transition<FastState>();
        }
    }
}
