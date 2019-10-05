using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : StateMachine
{
    public PlayerMovement movementHandler;
    protected AudioSource AudioSource;
    protected AudioClip audioClip;
    private AudioClip boink;
    private AudioClip suck;


    protected override void Awake()
    {
        movementHandler = GetComponent<PlayerMovement>();
        base.Awake();
    }


    protected void PlayBoink()
    {
        AudioSource.clip = boink;
    }


}
