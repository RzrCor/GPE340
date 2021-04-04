using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
   
    // How long the muzzle flash will last
    [SerializeField]
    float lifeTime = 0.2f;
    // Particle system on the muzzle flash
    ParticleSystem particles;


    void Awake()
    {
        // Gets particle system component
        particles = GetComponent<ParticleSystem>();
        // emits one particle
        particles.Emit(1);
        // Destroys the object after a set amount of time
        Destroy(gameObject, lifeTime);
    }


}
