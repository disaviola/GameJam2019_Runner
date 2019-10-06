using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    private float speed;
    [Range(0.5f, 10)]
    [SerializeField] private float startSpeed;
    [SerializeField] private float step = 0.003f;
    void Start()
    {
        speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        speed += step;
    }
    public float GetSpeed()
    {
        return speed;
    }
    public float GetStartSpeed()
    {
        return startSpeed;
    }
}
