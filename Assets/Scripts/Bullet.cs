using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // How long it's active before disappearing
    [SerializeField]
    float lifetime = 5f;
    // How much damage the bullet does
    [SerializeField]
    float bulletDamage = 10f;
    // Called whenever it collides with something
    private void OnCollisionEnter(Collision collision)
    {
        // Gets the health component that's on the object it collided with
        var health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            // Deals damage to object
            health.Damage(bulletDamage);
        }
        // Bullet disappears on hit
        Destroy(gameObject);
        
    }
    private void Start()
    {
        // Destroys itself after a certain amount of time
        Destroy(gameObject, lifetime);
    }
}