using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteWall : MonoBehaviour
{
    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera.transform.position.y - transform.position.y > 10f)
        {
            Destroy(gameObject);
        }
    }
}
