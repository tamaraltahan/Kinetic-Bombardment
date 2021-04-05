using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Base")]
    Rigidbody2D bod;
    public float lerpSpeed;
    public float attackTimer = 0.25f;
    float attackCD;
    public GameController controller;

    //public Text ammocountone;
    //experimenting with weapon switching
    //using this as a template, but not verbatim, since its missing some features like ammo, which we will have to set on a level to level basis.
    //https://answers.unity.com/questions/1775103/2d-weapon-switching-1.html
    [Header("Weapons")]
    public List<GameObject> weaponsList = new List<GameObject>(); //for ammunition, which contains logic
    public List<Sprite> gunsList = new List<Sprite>(); // for swapping weapon models
    public List<Sprite> ammoui = new List<Sprite>();
    private SpriteRenderer renderer;
    private SpriteRenderer ammouirenderer;

    public int currentIndex = 0;
    GameObject currentWeapon;

    public GameObject spawnObject;

    bool isMouseOnUI = false;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = gunsList[0];

        //ammouirenderer = GetComponent<SpriteRenderer>();
        //ammouirenderer.sprite = ammoui[0];

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
        //

        //change weapons

        //intent here is to be able to change weapon with scroll wheel
        //not very necessary but why not
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            if (scroll > 0) ScrollWeaponUp();
            else
                ScrollWeaponDown();
        }
        //

        //

        //attack
        isMouseOnUI = controller.evalMouse();
        if (Input.GetMouseButtonDown(0) && attackCD <= 0 && !isMouseOnUI) //left click & cd <= 0
        {
            if (currentWeapon.GetComponent<Weapon>().ammo > 0)
            {
                Shoot(currentWeapon);
                --currentWeapon.GetComponent<Weapon>().ammo; //decrement the weapon's ammo
                //ammocountone.text = currentWeapon.GetComponent<Weapon>().ammo.ToString();
                --controller.numAllAmmo; //decrement the ammo counter for book keeping.
                //Debug.Log("Current Ammo " + currentWeapon.GetComponent<Weapon>().ammo);
                //Debug.Log("Total Ammo " + controller.numAllAmmo);
            }
        }
        //decrement the attack cooldown
        if (attackCD > 0) attackCD -= Time.deltaTime;
        //

    }

    void SelectWeapon(int index)
    {
        currentWeapon = weaponsList[index];
        renderer.sprite = gunsList[index];
        //ammocountone.text = weaponsList[index].GetComponent<Weapon>().ammo.ToString();
        //ammouirenderer.sprite = ammoui[index];
    }

    //select next weapon based on scroll wheel (does not roll over - as in you have to scroll back down to get the 1st weapon)
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
        if(currentIndex > weaponsList.Count - 1)
        {
            nextIndex = weaponsList.Count - 1;
        }
        currentIndex = nextIndex;
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
        if(currentIndex < 0)
        {
            nextIndex = 0;
        }
        currentIndex = nextIndex;
        SelectWeapon(nextIndex);
    }

    void Shoot(GameObject pewpew)
    {
        Instantiate(pewpew, spawnObject.transform.position, spawnObject.transform.rotation);
        attackCD = attackTimer; //resets cooldown for attacks
    }

}
