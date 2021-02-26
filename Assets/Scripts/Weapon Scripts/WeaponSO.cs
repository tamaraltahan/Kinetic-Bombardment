using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//scriptable objects are data containers. This is an abstractions of all weapon types - holding basic data about each weapon we have
//this is essentially meta-data
[System.Serializable]
[CreateAssetMenu(fileName ="New Weapon", menuName = "Weapon")]
public class WeaponSO : ScriptableObject
{
    public string projName;
    public int maxAmmo;
    public int currentAmmo;
    public GameObject obj;

}
