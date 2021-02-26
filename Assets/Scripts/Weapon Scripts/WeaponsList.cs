using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsList : MonoBehaviour
{
    public List<WeaponSO> weaponsList;

    private void Start()
    {
        foreach(WeaponSO weapon in weaponsList)
        {
            weapon.currentAmmo = weapon.maxAmmo;
        }
    }
}
