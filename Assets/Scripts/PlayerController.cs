using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D bod;
    public float lerpSpeed;
    public float attackTimer = 0.25f;
    float attackCD;

    weaponType activeWeapon;
    public List<int> maxAmmoList;
    List<int> currentAmmoList;
    public enum weaponType
    {
        standard,
        bounce
    }

    // Start is called before the first frame update
    void Start()
    {

        bod = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //face the mouse cursor
        Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * lerpSpeed);




        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            if (scroll > 0) scrollWeaponUp();
            else
                scrollWeaponDown();

        }

        if (Input.GetMouseButtonDown(0) && attackCD <= 0)
        {
            shoot();
        }
        //decrement the attack cooldown
        if (attackCD > 0) attackCD -= Time.deltaTime;

    }

    void scrollWeaponUp()
    {

    }
    void scrollWeaponDown()
    {

    }

    void selectWeapon()
    {

    }


    void shoot()
    {
        //Instantiate()
        attackCD = attackTimer;
    }
}
