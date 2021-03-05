using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwapping : MonoBehaviour
{
    int WeaponHand = 1;
    public int currentWeapon;

    public GameObject weaponHolder;
    public GameObject[] weapons;
    public GameObject GunHand;
    
     // Start is called before the first frame update
    void Start()
    {
        WeaponHand = weaponHolder.transform.childCount;
        weapons = new GameObject[WeaponHand];

        for (int i = 0; i < WeaponHand; i++) 
        {
            weapons[i] = weaponHolder.transform.GetChild(i).gameObject;
            weapons[i].SetActive(false);

        }
        
        weapons[0].SetActive(true);
        GunHand = weapons[0];
        currentWeapon = 0;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.A))
       {
           if(currentWeapon < WeaponHand-1)
           {
               weapons[currentWeapon].SetActive(false);
               currentWeapon += 1;
               weapons[currentWeapon].SetActive(true);
            }

        }

       if(Input.GetKeyDown(KeyCode.Q))
       {  

           if (currentWeapon > 0)
           {
               weapons[currentWeapon].SetActive(false);
               currentWeapon -= 1;
               weapons[currentWeapon].SetActive(true);
        
            }
       
        }

    }
}
