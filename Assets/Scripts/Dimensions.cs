using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimensions : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    void Start()
    {
        minX = transform.position.x;
        maxX = transform.position.x;
        minY = transform.localScale.y;
        maxY = transform.localScale.y;
        foreach (Transform child in transform)
        {

            if (child.transform.position.x < minX)
            {
                minX = child.transform.position.x ;
            }
            if (child.transform.position.x > maxX)
            {
                maxX = child.transform.position.x  ;
            }
            if (child.transform.localScale.y < minY)
            {
                minY = child.transform.localScale.y ;
            }
            if (child.transform.localScale.y > maxY)
            {
                maxY = child.transform.localScale.y ;
            }
        }
    }
    public float GetMaxX()
    {
        return maxX;
    }
    public float GetMaxY()
    {
        return maxY;
    }
    public float GetMinY()
    {
        return minY;
    }
    public float GetMinX()
    {
        return minX;
    }
    public float GetHeight()
    {

        return maxY;
    }
    public float GetWidth()
    {
        return maxX - minX;
    }
}
