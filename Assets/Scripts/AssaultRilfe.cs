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
    [SerializeField]
    float timeBetweenShots = 0f;
    float _timer;
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
