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

    [Header("Weapons")]
    public List<GameObject> weaponsList = new List<GameObject>(); //for ammunition, which contains logic
    public List<Sprite> gunsList = new List<Sprite>(); // for swapping weapon models
    public List<Sprite> ammoui = new List<Sprite>();
    private SpriteRenderer renderer;
    public int currentIndex = 0;
    GameObject currentWeapon;

    public GameObject spawnObject;

    bool isMouseOnUI = false;

    public Text ammoUI;// used to change UI text

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = gunsList[0];

        //ammouirenderer = GetComponent<SpriteRenderer>();
        //ammouirenderer.sprite = ammoui[0];

        if(spawnObject == null) spawnObject = GameObject.Find("SpawnPt");
        currentWeapon = weaponsList[0];
        bod = GetComponent<Rigidbody2D>(); // set the active body
        ammoUI = GameObject.Find("Ammo").GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        //face the mouse cursor
        Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * lerpSpeed);
        ammoUI.text = "Current Ammo: " + currentWeapon.GetComponent<Weapon>().ammo; // ammo UI
        //

        //change weapons - scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            if (scroll > 0) ScrollWeaponUp();
            else
                ScrollWeaponDown();
        }
        //

        //attack
        isMouseOnUI = controller.evalMouse();
        if (Input.GetMouseButtonDown(0) && attackCD <= 0 && !isMouseOnUI) //left click & cd <= 0
        {
            if (currentWeapon.GetComponent<Weapon>().ammo > 0)
            {
                Shoot(currentWeapon);
                --currentWeapon.GetComponent<Weapon>().ammo; //decrement the weapon's ammo
                --controller.numAllAmmo; //decrement the ammo counter for book keeping.
            }
        }
        //decrement the attack cooldown
        if (attackCD > 0) attackCD -= Time.deltaTime;
        //

    }

    void SelectWeapon(int index)
    {
        Debug.Log(index);
        currentWeapon = weaponsList[index];
        renderer.sprite = gunsList[index];
    }

    //select next weapon based on scroll wheel (does not roll over - as in you have to scroll back down to get the 1st weapon)
    void ScrollWeaponUp()
    {
        int nextIndex;
        if(currentIndex == weaponsList.Count-1)
        {
            nextIndex = 0;
        }
        else
        {
            nextIndex = ++currentIndex;
        }
        currentIndex = nextIndex;
        SelectWeapon(currentIndex);
    }
    void ScrollWeaponDown()
    {
        int nextIndex;
        if (currentIndex == 0)
        {
            nextIndex = weaponsList.Count - 1;
        }
        else
        {
            nextIndex = --currentIndex;
        }
        currentIndex = nextIndex;
        SelectWeapon(currentIndex);
    }

    void Shoot(GameObject pewpew)
    {
        Instantiate(pewpew, spawnObject.transform.position, spawnObject.transform.rotation);
        attackCD = attackTimer; //resets cooldown for attacks
        Sound.PlaySound("shoot"); 
    }

}
