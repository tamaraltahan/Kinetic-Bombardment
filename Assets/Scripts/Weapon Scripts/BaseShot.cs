using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShot : Weapon
{
    public int speed;

    protected override void Awake()
    {
        bod = GetComponent<Rigidbody2D>();
    }

    protected void OnEnable()
    {
        bod.AddForce(transform.right * speed);
        Invoke("Disable", 5f);
    }
}
