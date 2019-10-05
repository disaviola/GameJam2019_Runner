using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject walls, hashtag;
    private GameObject lastWallAdded;
    [SerializeField]private Camera mainCamera;
    private int randomNumber, wallsBuilt;
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private int wallsBuiltBeforeObstacle = 20;


    private Color wallColor;
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
            randomNumber = Random.Range(1, 4);
            if (randomNumber == 1 && -(mainCamera.orthographicSize * 16 / 9) < lastWallAdded.GetComponent<Dimensions>().GetMinX()) //move next wall left
            {
                lastWallAdded = Instantiate<GameObject>(walls, new Vector2(lastWallAdded.transform.position.x - walls.transform.localScale.x, lastWallAdded.transform.position.y + lastWallAdded.transform.GetComponent<Dimensions>().GetHeight()/2 + walls.transform.localScale.y / 2), Quaternion.identity);
                RandomWallColor(lastWallAdded);
            }
            else if (randomNumber == 2 && (mainCamera.orthographicSize * 16 / 9) > lastWallAdded.GetComponent<Dimensions>().GetMaxX()) //move next wall right
            {
                lastWallAdded = Instantiate<GameObject>(walls, new Vector2(lastWallAdded.transform.position.x + walls.transform.localScale.x, lastWallAdded.transform.position.y + lastWallAdded.transform.GetComponent<Dimensions>().GetHeight()/2 + walls.transform.localScale.y/2), Quaternion.identity);
                RandomWallColor(lastWallAdded);
            }
            else if (wallsBuilt > wallsBuiltBeforeObstacle && randomNumber == 3 && obstacles.Length>0)
            {
                randomNumber = Random.Range(0, obstacles.Length);
                lastWallAdded = Instantiate<GameObject>(obstacles[randomNumber], new Vector2(lastWallAdded.transform.position.x, lastWallAdded.transform.position.y + walls.transform.localScale.y/2), Quaternion.identity);
                RandomWallColor(lastWallAdded);
                lastWallAdded.transform.position = new Vector2(lastWallAdded.transform.position.x, lastWallAdded.transform.position.y + 6);
                randomNumber = Random.Range(0, 3);
                switch (randomNumber)
                {
                    case 1:
                        lastWallAdded.transform.eulerAngles = new Vector3(0, 180, 0);
                        break;
                    case 2:
                        lastWallAdded.transform.eulerAngles = new Vector3(0, 180, 180);
                        break;
                    case 3:
                        lastWallAdded.transform.eulerAngles = new Vector3(0, 0, 180);
                        break;

                }
                wallsBuilt = 0;
            }
            else
            {

                lastWallAdded = Instantiate<GameObject>(walls, new Vector2(lastWallAdded.transform.position.x , lastWallAdded.transform.position.y + lastWallAdded.transform.GetComponent<Dimensions>().GetHeight()/2 + walls.transform.localScale.y/2), Quaternion.identity);
                RandomWallColor(lastWallAdded);
            }
            wallsBuilt++;
        }
        //if (wallsBuilt >10)
        //{
        //    randomNumber = Random.Range(0, 20);
        //    if (((float)randomNumber / wallsBuilt) > 0.5f)
        //    {

        //        Instantiate<GameObject>(hashtag, new Vector2(lastWallAdded.transform.position.x, lastWallAdded.transform.position.y), Quaternion.identity);
        //        wallsBuilt = 0;
        //    }
        //}
    }



    private void RandomWallColor(GameObject wall )
    {
    
       wallColor = Random.ColorHSV(0, 1, 1, 1, 1, 1, 1, 1);
        wall.GetComponentInChildren<Renderer>().material.color = wallColor;
    }
}
