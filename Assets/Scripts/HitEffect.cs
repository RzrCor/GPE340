using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    // How long the hit effect will display
    [SerializeField]
    float lifeTime = 0.2f;
    // Particle system on the hit effect
    ParticleSystem particles;
    // Prefab for playing the sound
    [SerializeField]
    SoundPlayer AudioPlayerPrefab;
    // The sound that plays when the bullet hits something
    [SerializeField]
    AudioClip HitSoundEffect;


    void Awake()
    {
        // Gets Particle system component
        particles = GetComponent<ParticleSystem>();
        // Emits one particle
        particles.Emit(1);
        // Creates the audio player
        var audioPlayer = GameObject.Instantiate(AudioPlayerPrefab, transform.position, Quaternion.identity);
        // Plays hit sound effect
        audioPlayer.PlaySound(HitSoundEffect);
        // Destroys object after set amount of time
        Destroy(gameObject, lifeTime);
    }
}
