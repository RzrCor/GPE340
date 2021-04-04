using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    // The audio source that plays the sound
    AudioSource audioSource;

    void Awake()
    {
        // Gets audio source component
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound)
    {
        // Sets the clip of the audio source to the current sound that's playing
        audioSource.clip = sound;
        // Plays audio source
        audioSource.Play();
        // Destroys the object after the sound is done playing
        Destroy(gameObject, sound.length);
    }
}
