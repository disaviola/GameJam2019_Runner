using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWall : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private SpeedManager speedManager;
    [SerializeField] private float speed = 6;

    void Start()
    {
        mainCamera = Camera.main;
        transform.localScale = new Vector2(mainCamera.orthographicSize * 2 * mainCamera.aspect , transform.localScale.y );
        transform.position = new Vector2(mainCamera.transform.position.x, mainCamera.transform.position.y - mainCamera.orthographicSize + transform.localScale.y/2);
        speed = speedManager.GetStartSpeed() * 1.2f;
    }

    void Update()
    {
        transform.position += new Vector3(0,  (speedManager.GetSpeed() + speed )* Time.deltaTime , 0);
    }
}
