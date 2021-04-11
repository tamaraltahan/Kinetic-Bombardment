using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticles : MonoBehaviour
{
    public ParticleSystem DestructionEffect; //assign prefab in editor or elsewhere
                                             //in code
    void Explode()
    {
        //Instantiate our one-off particle system
        ParticleSystem explosionEffect = Instantiate(DestructionEffect)
                                         as ParticleSystem;
        explosionEffect.transform.position = transform.position;
        //play it
        explosionEffect.loop = false;
        explosionEffect.Play();
        Sound.PlaySound("eyes"); 

        //destroy the particle system when its duration is up, right
        //it would play a second time.
        Destroy(explosionEffect.gameObject, explosionEffect.duration);
        //destroy our game object
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        Explode();
    }
}
