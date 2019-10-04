using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    private float speed = 8f;
    private Vector3 movement;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        addMovement();

    }

    private void addMovement()
    {
        Vector3 direction = (player.transform.position - gameObject.transform.position).normalized;
        gameObject.transform.position += direction * speed * Time.deltaTime;
    }



}
