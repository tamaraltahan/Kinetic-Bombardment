using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recast : Weapon
{
    public int speed;
    public float lerpSpeed;
    public bool didIShoot = false;
    public Transform firePoint;
    public GameObject recastedShot;

    protected override void Awake()
    {
        bod = GetComponent<Rigidbody2D>();
    }

    protected void OnEnable()
    {
        bod.AddForce(transform.right * speed);
        Invoke("Disable", 5f);
        didIShoot = false;
    }
    void Update()
    {
        Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * lerpSpeed);
        if (Input.GetMouseButtonDown(1))
        {
            if (didIShoot == false)
            {
                didIShoot = true;
                Instantiate(recastedShot, firePoint.position, firePoint.rotation);
                Invoke("Disable", 0f);
            }
        }

    }
}