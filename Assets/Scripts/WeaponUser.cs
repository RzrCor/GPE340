using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponUser : MonoBehaviour
{
    // Animator component on the character
    Animator animator;
    // Object used for holding the weapon
    [SerializeField]
    GameObject weaponContainer;
    // Currently equipped weapon on player
    public GameObject CurrentlyEquippedWeapon;
    // Allows us to set a starting weapon
    [SerializeField]
    Weapon startingWeapon;
    // The on weapon equipped event
    [SerializeField]
    UnityEvent<Weapon> OnWeaponEquipped;
    void Start()
    {
        // Gets the animator component on the character
        animator = GetComponent<Animator>();
        if (startingWeapon != null)
        {
            EquipWeapon(startingWeapon.gameObject);
        }
    }
    // Equips weapon to the player
    public void EquipWeapon(GameObject weaponToEquip)
    {
        if (CurrentlyEquippedWeapon != null)
        {
            Destroy(CurrentlyEquippedWeapon);
        }
        //Creates a copy of the gun prefab
        var gunCopy = GameObject.Instantiate(weaponToEquip);
        // Sets the name of the copy
        gunCopy.name = weaponToEquip.name;
        // Sets the new copy to the weapon container
        gunCopy.transform.SetParent(weaponContainer.transform);
        // Positions the gun correctly on the weapon container
        gunCopy.transform.localPosition = Vector3.zero;
        // Rotates the gun correctly on the weapon container
        gunCopy.transform.localRotation = Quaternion.identity;
        // Sets the currently equipped weapon
        CurrentlyEquippedWeapon = gunCopy;
        // calls the on weapon equipped event
        if (OnWeaponEquipped != null)
        {
            OnWeaponEquipped.Invoke(CurrentlyEquippedWeapon.GetComponent<Weapon>());
        }
    }

    private void OnAnimatorIK(int layerIndex)
    {
        // Checks if we have a weapon equipped
        if (CurrentlyEquippedWeapon != null)
        {
            // Enables inverse kinematics for left and right hands
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            // Gets the position of the left and right hands
            var rightHandPosition = CurrentlyEquippedWeapon.transform.Find("RightHandPosition");
            var leftHandPosition = CurrentlyEquippedWeapon.transform.Find("LeftHandPosition");
            // Sets the position of the right and left hands
            animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandPosition.transform.position);
            animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandPosition.transform.position);
            animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandPosition.transform.rotation);
            animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandPosition.transform.rotation);
        }
        else
        {
            // If no gun is equipped, disable inverse kinematics
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
        }
    }

    public void ShootWeapon(Vector3 target)
    {
        // Check if a weapon is equipped
        if (CurrentlyEquippedWeapon != null)
        {
            // Get the weapon component and cause it to shoot at the point
            CurrentlyEquippedWeapon.GetComponent<Weapon>().Shoot(target);
        }
    }


}
