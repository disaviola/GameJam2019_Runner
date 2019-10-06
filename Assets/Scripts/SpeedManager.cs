using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    private float speed;
    void Start()
    {
        speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        speed += 0.0001f;
    }
    public float GetSpeed()
    {
        return speed;
    }
}
