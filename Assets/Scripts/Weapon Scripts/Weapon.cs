using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected Rigidbody2D bod;
    public GameObject explosion;
    public int ammo;

    protected abstract void Awake();

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        //destroys enemy it hits, then destroys the projectile
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Destroy(collision.GetComponent<Rigidbody2D>());
            collision.gameObject.GetComponent<Enemy1>().Deactivate();
            //collision.gameObject.SetActive(false);
            //Instantiate(explosion, transform.position, transform.rotation);
            //gameObject.SetActive(false);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        //if it hits a boss weakspot
        if (collision.gameObject.CompareTag("BossWeakSpot"))
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
