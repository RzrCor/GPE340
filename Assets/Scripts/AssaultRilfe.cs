using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRilfe : Weapon
{
    // Calls bullet prefab
    [SerializeField]
    GameObject BulletPrefab;
    // Takes bullet velocity
    [SerializeField]
    float bulletVelocity;
    // Position of the muzzle
    [SerializeField]
    GameObject Muzzle;
    // Fire rate for weapon
    float _timer;
    // Allows us to set the damage in the inspector
    [SerializeField]
    float damage = 10f;
    // The sound for when the gun shoots
    [SerializeField]
    AudioClip shootSound;
    // Prefab for the muzzle flash
    [SerializeField]
    GameObject MuzzleFlashPrefab;
    // Prefab for playing the shoot sound
    [SerializeField]
    SoundPlayer AudioPlayerPrefab;
    public override void Shoot(Vector3 target)
    {
        // If timer is less than or equal to 0
        if (_timer <= 0f)
        {
            // Make a bullet copy
            var bulletCopy = GameObject.Instantiate(BulletPrefab);
            // Position bullet at the muzzle
            bulletCopy.transform.position = Muzzle.transform.position;
            // Get the rigidbody of the bullet
            var bulletRigidbody = bulletCopy.GetComponent<Rigidbody>();
            // Gets the bullet component
            var bullet = bulletCopy.GetComponent<Bullet>();
            // Sets bullets damage to what it's set as in the inspector
            bullet.bulletDamage = damage;
            // Create a vector that points towards the target
            Vector3 bulletDirection = target - bulletCopy.transform.position;
            // Normalize the vector to a length of one
            bulletDirection.Normalize();
            // Multiply it by bullet velocity
            bulletDirection *= bulletVelocity;
            // Set the velocity by the bullet's rigidbody
            bulletRigidbody.velocity = bulletDirection;
            // Reset fire rate timer
            _timer = timeBetweenShots;
            // Creates the audio player
            var audioPlayer = GameObject.Instantiate(AudioPlayerPrefab, Muzzle.transform.position, Quaternion.identity);
            // Plays shoot sound effect
            audioPlayer.PlaySound(shootSound);
            // Creates the muzzle flash
            GameObject.Instantiate(MuzzleFlashPrefab, Muzzle.transform.position, Quaternion.identity);
        }
    }
    private void Update()
    {
        // If timer is greater than 0 it will countdown
        if (_timer > 0f)
        {
            // Decrease the countdown timer
            _timer = _timer - Time.deltaTime;
        }
    }
}
