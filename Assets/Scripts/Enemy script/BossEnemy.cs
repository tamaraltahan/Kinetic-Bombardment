using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy1
{
    public float maxHp = 2;
    private float curHp;
    public bool alive = true;
    public GameObject Weakspot1;
    public GameObject Weakspot2;

    private void Awake()
    {
        curHp = maxHp;
        if (wayPoint1 != null)
            targetPos = wayPoint1.transform.position;
        else
        {
            targetPos = transform.position;
        }
    }

    void Update()
    {
        MoveToWayPoints();
        if (Weakspot1 == null && Weakspot2 == null)
        {
            Deactivate();
        }
    }

    void DoDamage()
    {
        if (Weakspot1 != null)
        {
            takeDamage(1);
            Destroy(Weakspot1);
                 
        }
        if(Weakspot2 != null)
        {
            takeDamage(1);
            Destroy(Weakspot2);
        }
    }
    
    public void takeDamage(int n)
    {            
        curHp -= n;
        if(curHp <= 0)
        {
            Deactivate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        //swap way points when we collide with it - invisible collission
        if (collision.CompareTag("EndPoint"))
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
