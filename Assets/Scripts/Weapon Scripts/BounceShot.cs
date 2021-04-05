using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceShot : Weapon
{
    public int MaxBounces;
    int currBounces = 0;
    public float speed;
    Vector2 lastVel;
    protected override void Awake()
    {
        bod = GetComponent<Rigidbody2D>();
        //bod.gravityScale = 1;
    }

    private void OnEnable()
    {
        bod.AddForce(transform.right * speed);
        Invoke("Disable", 3f);
    }

    private void Update()
    {
        lastVel = bod.velocity; //for obtaining bouncing normal vectors
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        //limit the set of bounces
        currBounces++;
        if(currBounces == MaxBounces)
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            float speed = lastVel.magnitude;
            Vector2 dir = Vector2.Reflect(lastVel.normalized, collision.contacts[0].normal);
            bod.velocity = dir * Mathf.Max(speed, 0f);
        }
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
        if (collision.gameObject.CompareTag("BossWeakSpot"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
