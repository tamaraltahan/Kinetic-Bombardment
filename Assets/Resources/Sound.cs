using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    public static AudioClip shootSound, impactSound, enemySound, eyesSound, bounceSound, bossSound;
    static AudioSource audioS;
    void Start()
    {
        
        shootSound = Resources.Load<AudioClip> ("shoot");
        impactSound = Resources.Load<AudioClip> ("impact");
        enemySound = Resources.Load<AudioClip> ("enemy");
        eyesSound = Resources.Load<AudioClip> ("eyes");
        bounceSound = Resources.Load<AudioClip> ("bounce");
        bossSound = Resources.Load<AudioClip> ("boss");
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
            case "eyes" :
            audioS.PlayOneShot (eyesSound);
            break;
            case "bounce" :
            audioS.PlayOneShot (bounceSound);
            break;
            case "boss" :
            audioS.PlayOneShot (bossSound);
            break;
        }
    }
}
