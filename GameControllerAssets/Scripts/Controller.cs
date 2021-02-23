using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
   
   public Transform Start; 
   public GameObject ShotBullet; 
   public float lerspd; 
     void Update() {
          Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        
          float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
          transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * lerspd);
        
        if (Input.GetButtonDown("Mouse"))
        {
            Shoot();
        }
    }

    void Shoot ()
    {
       Instantiate(ShotBullet, Start.position, Start.rotation);
    }
}