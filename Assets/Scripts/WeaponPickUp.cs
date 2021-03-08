using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : PickUp
{
    // Weapon to equip
    [SerializeField]
    GameObject weapon;

    public override void OnPickup(CharacterController character)
    {
        // Equip weapon to player
        character.GetComponent<WeaponUser>().EquipWeapon(weapon);
    }
}
