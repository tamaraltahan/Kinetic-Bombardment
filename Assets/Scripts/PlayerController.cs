using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D bod;
    public float lerpSpeed;
    public float attackTimer = 0.25f;
    float attackCD;


    //experimenting with weapon switching
    //using this as a template, but not verbatim, since its missing some features like ammo, which we will have to set on a level to level basis.
    //https://answers.unity.com/questions/1775103/2d-weapon-switching-1.html
    weaponType activeWeapon;
    public List<int> maxAmmoList = new List<int>();
    List<int> currentAmmoList = new List<int>();

    List<weaponType> weaponsList = new List<weaponType>(); //maybe will do active weapons vs all weapons (?)

    GameObject weaponObj; //this needs to be set somehow :/

    
    public enum weaponType
    {
        standard,
        bounce
    }
    //

    // Start is called before the first frame update
    void Start()
    {
        bod = GetComponent<Rigidbody2D>(); // set the active body
    }

    void setAmmo()
    {
        //for each weapon in the list, set current ammo to max ammo
        for (int i = 0; i < maxAmmoList.Count; ++i)
        {
            currentAmmoList[i] = maxAmmoList[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        //face the mouse cursor
        Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * lerpSpeed);



        //intent here is to be able to change weapon with scroll wheel
        //not very necessary but why not
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            if (scroll > 0) scrollWeaponUp();
            else
                scrollWeaponDown();

        }

        if (Input.GetMouseButtonDown(0) && attackCD <= 0)
        {
            shoot(weaponObj);
        }
        //decrement the attack cooldown
        if (attackCD > 0) attackCD -= Time.deltaTime;

    }

    //to do
    void scrollWeaponUp()
    {

    }
    void scrollWeaponDown()
    {

    }

    void shoot(GameObject pewpew)
    {
        Instantiate(pewpew, transform.position, Quaternion.identity);
        attackCD = attackTimer;
    }

    void selectWeapon(weaponType weapon)
    {
        switch (weapon)
        {
            case weaponType.standard:
                activeWeapon = weaponType.standard;
                //weaponObj = something
                break;
            case weaponType.bounce:
                activeWeapon = weaponType.bounce;
                break;
            default:
                break;
        }
    }
}
