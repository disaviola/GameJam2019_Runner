﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRockets : MonoBehaviour
{

    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = player.transform.position;
    }
}
