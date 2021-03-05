using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    //GameObject obj;
    protected Rigidbody2D bod;

    // Start is called before the first frame update
    //protected virtual void Start()
    //{
    //    bod = GetComponent<Rigidbody2D>();
    //}

    protected abstract void Awake();


    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //Break the object if it hits a wall;
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        //destroys enemy it hits, then destroys the projectile
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.GetComponent<Rigidbody2D>());
            Destroy(gameObject);
        }
        //if it hits a boss weakspot
        if (collision.CompareTag("BossWeakSpot"))
        {
            //will enable this when enemy controller script is live with a takeDamage(int n) functions
            //collision.GetComponent<EnemyController>().takeDamage(damage);
            Destroy(gameObject);
        }
    }


    protected virtual void Disable()
    {
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
