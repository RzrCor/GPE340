using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : PickUp
{
    // Amount pickup heals
    [SerializeField]
    float healAmount = 25f;

    public override void OnPickup(Character character)
    {
        // Gets player's health function and heals by amount set for pickup
        character.GetComponent<Health>().Heal(healAmount);
    }
}
