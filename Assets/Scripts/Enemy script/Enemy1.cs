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

    public GameObject explosion;

    private void Awake()
    {
        if(wayPoint1 != null)
       targetPos = wayPoint1.transform.position;
    }
    void Update()
    {
        //move towards target way point
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //swap way points when we collide with it - invisible collission
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

    public void Deactivate()
    {
        FindObjectOfType<EnemyRespawner>().enemyCount--;
        Instantiate(explosion, transform.position, Quaternion.identity);
        Debug.Log("Explosion instantiated");
        Invoke("Disable", 0.001f);
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

}
