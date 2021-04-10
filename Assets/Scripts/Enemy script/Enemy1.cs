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
    GameObject respawner;

    private void Awake()
    {
        if(wayPoint1 != null)
       targetPos = wayPoint1.transform.position;
        else
        {
            targetPos = transform.position;
        }
    }

    protected void MoveToPoints()
    {
        //move towards target way point
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    void Update()
    {

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
    //convoluted destroy logic - had to get REALLY creative with it in my attempt at deugging the explosion
    //Credit to Cole, who generously helped me late at night to fix it, although the solution came out kinda janky
    public void Deactivate()
    {
        respawner = GameObject.Find("EnemyRespawner");
        if (respawner)
        {
            FindObjectOfType<EnemyRespawner>().enemyCount--;
        }
        Instantiate(explosion, transform.position, Quaternion.identity);
        Debug.Log("Explosion instantiated");
        Invoke("Disable", 0.001f);
        Sound.PlaySound("enemy"); 
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
