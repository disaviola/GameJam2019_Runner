using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 input, inputPreviousFrame;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float slowSpeed;
    [SerializeField] private float fastSpeed;
    [SerializeField] private float boostSpeed;
    [SerializeField] private float slowedDownModifier = -1f;
    [SerializeField] private GameObject player;
    private Vector3 originalScale;
    [SerializeField] private float playerWidth = 3.5f;
    [SerializeField] private MySceneManager SceneManager;
    [SerializeField] private GameObject rockets;
    [SerializeField] private GameObject uprightRocket;

    private bool isFast = false;
    private bool isSlowedDown = false;
    private int rocketMode = 0;
    private bool isBoosted;
    [SerializeField] private SpeedManager speedManager;

    private void Start()
    {
        slowSpeed = speedManager.GetStartSpeed();
        fastSpeed = slowSpeed * 2;
        boostSpeed = fastSpeed * 2;
        originalScale = player.transform.localScale;
        
    }

    void Update()
    {
        ActivateRocketMode();

        Debug.Log(speed);
        if (isFast)
        {
            if (isBoosted)
            {
                speed = boostSpeed;
            }
            else
            {
                speed = fastSpeed;
            }

            speed = speed * 1.0008f;
        }


        //if (isSlowedDown)
        //{
        //    speed += slowedDownModifier;
        //}


    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Walls")
        {
            //Debug.Log("You died");

            SceneManager.Die();
        }
    }

    public void SetMovement()
    {

        transform.Translate(0f, (speed  + speedManager.GetSpeed())* Time.deltaTime, 0f);
        input = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        if (!Input.anyKey)
        {
            input = Vector3.zero;
        }
        input = input.normalized;
        transform.position += input * Time.deltaTime * 8;
        inputPreviousFrame = input;
    }

    void SetSpeed()
    {
        if (speed == slowSpeed)
        {
            speed = fastSpeed;
            isFast = true;
            player.transform.localScale += new Vector3(playerWidth, 0, 0);
            return;
        }
        else if (speed == fastSpeed)
        {
            speed = slowSpeed;
            isFast = false;
            player.transform.localScale = originalScale;
        }

    }

    public void SetBoost (bool boolean)
    {
        isBoosted = boolean;
    }
    
    public void SetSpeedMode(bool isFastInput, float originalSpeed)
    {
        if (isFastInput == true)
        {
            isFast = true;
            speed = fastSpeed;
        }
        else
        {
            isFast = false;
            speed = slowSpeed;
        }
    }

    public void ActivateRocketMode()
    {
        if (rocketMode == 0)
        {
            rockets.SetActive(false);
            uprightRocket.SetActive(false);
        }

        if (rocketMode == 1)
        {
            rockets.SetActive(true);
            uprightRocket.SetActive(false);

        }

        if (rocketMode == 2)
        {
            rockets.SetActive(false);
            uprightRocket.SetActive(true);
        }
    }

    public void SetRocketMode(int mode)
    {
        rocketMode = mode;
    }

    public void SetSlowedDown(bool isSlowed)
    {
        isSlowedDown = isSlowed;
    }


}
