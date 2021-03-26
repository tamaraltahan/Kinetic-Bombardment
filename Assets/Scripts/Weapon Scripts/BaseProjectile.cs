using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    Rigidbody2D projectile;
    public float projSpeed;
    public int damage;
    public GameObject explosion;

    private void Awake()
    {
        projectile = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        //Projectile will move forward from the point of origin
        projectile.AddForce(Vector2.up * projSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Break the object if it hits a wall;
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        //destroys enemy it hits, then destroys the projectile
        if (collision.CompareTag("Enemy"))
        {
            //Destroy(collision.GetComponent<Rigidbody2D>());
            collision.GetComponent<Enemy1>().Deactivate();
            //collision.gameObject.SetActive(false);
            Instantiate(explosion,transform.position,transform.rotation);
            gameObject.SetActive(false);
        }
        //if it hits a boss weakspot
        if (collision.CompareTag("BossWeakSpot"))
        {
            //will enable this when enemy controller script is live with a takeDamage(int n) functions
            //collision.GetComponent<EnemyController>().takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
