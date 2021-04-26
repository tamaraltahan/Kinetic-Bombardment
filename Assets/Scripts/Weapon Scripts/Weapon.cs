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
        //Debug.Log("Hit: " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            Sound.PlaySound("impact");
        }
        //destroys enemy it hits, then destroys the projectile
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy1>().Deactivate();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        //if it hits a boss weakspot
        if (collision.gameObject.CompareTag("BossWeakSpot"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }

    protected virtual void Disable()
    {
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
