using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offset : MonoBehaviour
{
    [SerializeField] private float offset = 5f;
    [SerializeField] private GameObject leftWall, rightWall;
    public float GetOffset()
    {
        return offset;
    }
}
