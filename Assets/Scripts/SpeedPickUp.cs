using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickUp : PickUp
{
    // Allows increased speed for pickup to be set
    [SerializeField]
    float fasterSpeed = 6f;

    public override void OnPickup(CharacterController character)
    {
        // Sets character speed to pickup speed
        character.SetSpeed(fasterSpeed);
    }
}
