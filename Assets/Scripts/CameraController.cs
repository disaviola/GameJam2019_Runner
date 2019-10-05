using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    Vector3 tempVec3 = new Vector3();

    void LateUpdate()
    {
        tempVec3.y = targetTransform.position.y;
        tempVec3.x = this.transform.position.x;
        tempVec3.z = targetTransform.position.z - 5;
        this.transform.position = tempVec3;
    }
}
