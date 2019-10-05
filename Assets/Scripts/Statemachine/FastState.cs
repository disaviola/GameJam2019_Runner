using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Player/FastState")]
public class FastState : BaseState
{
    [SerializeField] private float playerWidth = 3.5f;
    public override void Enter()
    {
        Debug.Log("Fast");
        owner.transform.localScale = new Vector3(1, 1, 1);
        owner.transform.localScale += new Vector3(playerWidth, 0, 0);
        owner.movementHandler.SetSpeedMode(true, originalSpeed);
        SFXmanager.SFXIntsance.PlayBoink();
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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            owner.Transition<UprightFastState>();
        }

    }
}
