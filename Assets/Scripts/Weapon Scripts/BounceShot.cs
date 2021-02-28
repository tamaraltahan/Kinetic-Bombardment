using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceShot : Weapon
{
    public float speed;
    protected override void Awake()
    {
        bod = GetComponent<Rigidbody2D>();
        bod.gravityScale = 1;
    }

    private void OnEnable()
    {
        bod.AddForce(Vector3.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
