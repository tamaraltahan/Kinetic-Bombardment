using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public string projName;
    public int maxAmmo;
    public int currentAmmo;
    //GameObject obj;
    Rigidbody2D bod;

    // Start is called before the first frame update
    void Start()
    {
        //obj = GetComponent<GameObject>();
        bod = GetComponent<Rigidbody2D>();
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        
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
            Destroy(collision.GetComponent<Rigidbody2D>());
            Destroy(gameObject);
        }
        //if it hits a boss weakspot
        if (collision.CompareTag("BossWeakPoint"))
        {
            //will enable this when enemy controller script is live with a takeDamage(int n) functions
            //collision.GetComponent<EnemyController>().takeDamage(damage);
            Destroy(gameObject);
        }
    }

}
