using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyPosition = new Vector2(player.transform.position.x, wall.transform.position.y);
        gameObject.transform.position = enemyPosition;
    }
}
