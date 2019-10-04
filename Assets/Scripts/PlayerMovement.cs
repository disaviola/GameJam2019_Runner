using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 input, inputPreviousFrame;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float slowSpeed = 5f;
    [SerializeField] private float fastSpeed = 10f;


    void Update()
    {
        SetMovement();
        if(Input.GetKeyDown("x"))
        {
            SetSpeed();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Walls")
        {
            Debug.Log("You died");
        }
    }

    private void SetMovement()
    {

        transform.Translate(0f, speed * Time.deltaTime, 0f);
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
            return;
        }
        else if (speed == fastSpeed)
        {
            speed = slowSpeed;
        }
    }

}
