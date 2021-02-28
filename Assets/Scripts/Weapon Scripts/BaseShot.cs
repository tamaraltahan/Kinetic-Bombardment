using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShot : Weapon
{
    public int speed;

    protected override void Awake()
    {
        bod = GetComponentInChildren<Rigidbody2D>();
    }

    protected void OnEnable()
    {
        bod.AddForce(Vector3.forward * speed);
    }
}
