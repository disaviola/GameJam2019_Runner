using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 input, inputPreviousFrame;
    [SerializeField] private float speed = 5f;

    void Update()
    {
        SetMovement();
    }
    private void SetMovement()
    {
        
        transform.Translate(0f, speed * Time.deltaTime, 0f);
        input = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        //if (input.magnitude<1 )
        //{
        //    input = Vector3.zero;
        //}
        input = input.normalized;
        transform.position += input * Time.deltaTime * 8;
        inputPreviousFrame = input;
    }
}
