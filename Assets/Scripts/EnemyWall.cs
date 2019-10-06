using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWall : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private SpeedManager speedManager;
    [Range(1, 2)]
    [SerializeField] private float speedCoef = 1.3f;
    private float speed ;

    void Start()
    {
        mainCamera = Camera.main;
        transform.localScale = new Vector2(mainCamera.orthographicSize * 2 * mainCamera.aspect , transform.localScale.y );
        transform.position = new Vector2(mainCamera.transform.position.x, mainCamera.transform.position.y - mainCamera.orthographicSize + transform.localScale.y/2);
        speed = speedManager.GetStartSpeed() * speedCoef;
    }

    void Update()
    {
        transform.Translate(0f,  (speedManager.GetSpeed() + speed) * Time.deltaTime, 0f);

    }
}
