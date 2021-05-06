using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastRadiusShot : Weapon
{

    public int speed;
    public float BlastRadius = 2f;
    protected override void Awake()
    {
        bod = GetComponent<Rigidbody2D>();
    }

    protected void OnEnable()
    {
        bod.AddForce(transform.right * speed);
        Invoke("Disable", 5f);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if(BlastRadius > 0)
        {
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, BlastRadius);
            foreach (var hitCollider in hitColliders)
            {
                var enemy = hitCollider.GetComponent<Enemy1>();
                if(enemy)
                {
                    var closestPoint = hitCollider.ClosestPoint(transform.position);
                    var distance = Vector3.Distance(closestPoint, transform.position);

                    var damagePercent = Mathf.InverseLerp(BlastRadius, 1 , distance);
                    enemy.Deactivate();
                }
            }
        }

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
}
