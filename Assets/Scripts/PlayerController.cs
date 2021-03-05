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
    public List<GameObject> weaponsList = new List<GameObject>();
    int currentIndex = 0;
    GameObject currentWeapon;
    public GameObject spawnObject;

    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = weaponsList[0];
        bod = GetComponent<Rigidbody2D>(); // set the active body
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
            if (scroll > 0) ScrollWeaponUp();
            else
                ScrollWeaponDown();
        }

        if (Input.GetMouseButtonDown(0) && attackCD <= 0)
        {
            Shoot(currentWeapon);
        }
        //decrement the attack cooldown
        if (attackCD > 0) attackCD -= Time.deltaTime;

    }

    //to do
    void SelectWeapon(int index)
    {
        currentWeapon = weaponsList[index];
    }
    void ScrollWeaponUp()
    {
        int nextIndex;
        if(currentIndex == 0)
        {
            nextIndex = weaponsList.Count - 1;
        }
        else
        {
            nextIndex = ++currentIndex;
        }
        SelectWeapon(nextIndex);
    }
    void ScrollWeaponDown()
    {
        int nextIndex;
        if (currentIndex == 0)
        {
            nextIndex = 0;
        }
        else
        {
            nextIndex = --currentIndex;
        }
        SelectWeapon(nextIndex);
    }

    void Shoot(GameObject pewpew)
    {
        Instantiate(pewpew, spawnObject.transform.position, spawnObject.transform.rotation);
        attackCD = attackTimer;
    }

}
