using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    public static AudioClip shootSound, impactSound, enemySound;
    static AudioSource audioS;
    void Start()
    {
        
        shootSound = Resources.Load<AudioClip> ("shoot");
        impactSound = Resources.Load<AudioClip> ("impact");
        enemySound = Resources.Load<AudioClip> ("enemy");
    }
    void Update()
    {
       audioS = GetComponent<AudioSource> ();
    }

    public static void PlaySound(string sound)
    {
        switch (sound)
        {
            case "shoot" :
            audioS.PlayOneShot (shootSound);
            break;
            case "impact" :
            audioS.PlayOneShot (impactSound);
            break;
            case "enemy" :
            audioS.PlayOneShot (enemySound);
            break;
        }
    }
}
