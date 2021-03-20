using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    //travel between 2 points
    public GameObject wayPoint1;
    public GameObject wayPoint2;

    Vector2 targetPos;

    public float speed;
    bool atFirstMark = true;
    // Update is called once per frame

    private void Awake()
    {
       targetPos = wayPoint1.transform.position;
    }
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EndPoint")
        {
            if (atFirstMark)
            {
                targetPos = wayPoint2.transform.position;
                atFirstMark = false;
            }
            else
            {
                targetPos = wayPoint1.transform.position;
                atFirstMark = true;
            }
        }
    }
}
