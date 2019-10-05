using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hashtag : MonoBehaviour
{
    [SerializeField] private GameObject hashtag;
    private GameObject instantiated;
    private float randomX, randomY;
    void Start()
    {
        randomX = Random.Range(0, 3);
        randomY = Random.Range(0, 3);
        instantiated = Instantiate<GameObject>(hashtag, new Vector2(randomX + transform.position.x, randomY + transform.position.y), Quaternion.identity,gameObject.transform);
    }

}
