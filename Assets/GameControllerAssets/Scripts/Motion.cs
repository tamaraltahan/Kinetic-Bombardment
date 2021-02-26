using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour {

    public float speed = 55f;
    public Rigidbody2D bullet;

    void Start () {
        bullet.velocity = transform.right * speed;
    }
}