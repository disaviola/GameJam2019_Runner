using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : StateMachine
{
    public PlayerMovement movementHandler;

    protected override void Awake()
    {
        movementHandler = GetComponent<PlayerMovement>();
        base.Awake();
    }
}
