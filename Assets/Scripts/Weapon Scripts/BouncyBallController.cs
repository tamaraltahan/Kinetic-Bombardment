using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBallController : MonoBehaviour
{
    Rigidbody2D projectile;
    public float projSpeed;
    public int damage;

    //limited number of bounces
    public int maxBounces = 3;
    int currentBounces = 0;


    private void Awake()
    {
        projectile = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        //Projectile will move forward from the point of origin
        projectile.AddForce(Vector2.up * projSpeed);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentBounces++;
    
        //If we hit an enemy - destroy enemy but keep the projectile
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }

        //if a boss weak point is hit, deal damage, but dont destroy the projectile
        if (collision.gameObject.CompareTag("BossWeakSpot"))
        {
            //collsion.GetComponent<EnemyController>().takeDamage(damage);
        }

        //break after max bounces
        if (currentBounces > maxBounces)
        {
            Destroy(gameObject);
        }
    }

}
