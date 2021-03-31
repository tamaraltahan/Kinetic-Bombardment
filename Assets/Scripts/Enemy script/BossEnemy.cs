using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy1
{
    public float maxHp = 2;
    public float curHp = 2;
    public bool alive = true;
    public GameObject Weakspot1;
    public GameObject Weakspot2;
    
    void start()
    {
        alive = true;
        curHp = maxHp;
    }
    
    void DoDamage()
    {
        if(Weakspot1 != null)
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
        if (!alive)
        {
            return;
        }
        if(curHp <= 0)
        {
            curHp = 0;
            alive = false;
        }
        curHp -= n;
    }
}
