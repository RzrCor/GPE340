using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(Rigidbody))]
public abstract class PickUp : MonoBehaviour
{
    // Makes all child classes inherit whats in this function
    // This funtion is polymorphic because the functionality changes depending on what pickup it is
    public abstract void OnPickup(CharacterController character);

    private void OnCollisionEnter(Collision collision)
    {
        // Checks if the layer is for Player
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Get the character controller component and pass it into the on pick up function
            OnPickup(collision.gameObject.GetComponent<CharacterController>());
            // Pickup will disappear after pick up
            Destroy(gameObject);
        }
    }

}