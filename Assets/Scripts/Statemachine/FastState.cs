using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Player/FastState")]
public class FastState : BaseState
{
    [SerializeField] private float playerWidth = 3.5f;
    bool reseted = false;

    public override void Enter()
    {
        Debug.Log("Fast");
        //owner.transform.localScale = new Vector3(1, 1, 1);
        //owner.transform.localScale += new Vector3(playerWidth, 0, 0);
        owner.movementHandler.SetSpeedMode(true, originalSpeed);
        SFXmanager.SFXIntsance.PlayBoink();
    }

    public override void HandleFixedUpdate()
    {
        if (!reseted && owner.transform.localScale.y > 1)

        {
            Debug.Log("reseting");
            owner.transform.localScale -= new Vector3(0, 4, 0) * 7 * Time.deltaTime;
        }
        if (owner.transform.localScale == new Vector3(1, 1, 1))
        {
            reseted = true;
        }

        if (reseted && owner.transform.localScale.x < 3.5f)
        {
            owner.transform.localScale += new Vector3(playerWidth, 0, 0) * 7 * Time.deltaTime;
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
            owner.Transition<UprightFastState>();
        }

    }

    public override void Exit()
    {
        reseted = false;
    }

}
