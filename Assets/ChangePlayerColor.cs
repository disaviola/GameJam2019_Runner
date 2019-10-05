using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerColor : MonoBehaviour
{

    Renderer ren;
    private void Awake()
    {
        ren = GetComponent<Renderer>();
    }
    private void Start()
    {
        InvokeRepeating("ChangeColor", 0 ,0.5f);
    }

    private void ChangeColor()
    {
        ren.material.color = Random.ColorHSV(0, 1, 1, 1, 1, 1, 1, 1);
    }
}
