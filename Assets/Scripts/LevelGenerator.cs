using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject walls;
    private GameObject lastWallAdded;
    [SerializeField]private Camera mainCamera;
    private int randomNumber;

    void Start()
    {

        lastWallAdded = Instantiate<GameObject>(walls);
        while (lastWallAdded.transform.position.y < mainCamera.transform.position.y + mainCamera.orthographicSize*2 )
        {
            lastWallAdded = Instantiate<GameObject>(walls, new Vector2(0, lastWallAdded.transform.position.y + walls.transform.localScale.y), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera.transform.position.y + mainCamera.orthographicSize * 2 - lastWallAdded.transform.position.y > 0.5f)
        {
            randomNumber = Random.Range(1, 3);
            if (randomNumber == 1 && -(mainCamera.orthographicSize * 16 / 9) < lastWallAdded.transform.position.x - 5) //move next wall left
            {
                lastWallAdded = Instantiate<GameObject>(walls, new Vector2(lastWallAdded.transform.position.x - walls.transform.localScale.x, lastWallAdded.transform.position.y + walls.transform.localScale.y), Quaternion.identity);
            }
            else if (randomNumber == 2 && (mainCamera.orthographicSize *16/9) >lastWallAdded.transform.position.x +5 ) //move next wall right
            {
                lastWallAdded = Instantiate<GameObject>(walls, new Vector2(lastWallAdded.transform.position.x + walls.transform.localScale.x, lastWallAdded.transform.position.y + walls.transform.localScale.y), Quaternion.identity);
            }
            else
            {

            }
        }
    }
}
