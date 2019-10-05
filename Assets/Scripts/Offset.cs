using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offset : MonoBehaviour
{
    [SerializeField] private float offset = 5f;
    [SerializeField] private GameObject leftWall, rightWall;
    private BoxCollider leftCollider, rightCollider;

    private void Start()
    {
        leftWall.transform.position = new Vector3(-offset, leftWall.transform.position.y);
        rightWall.transform.position = new Vector3(offset, rightWall.transform.position.y);
    }
    public float GetOffset()
    {
        return offset;
    }
}
