using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character 
{
    // Component used to let the enemy navigate the navmesh
    NavMeshAgent navAgent;
    // The component that lets the enemy use weapons
    WeaponUser weaponUser;
    // Makes enemy target the player
    [SerializeField]
    Player targetPlayer;
    // Allows enemy to use pickups
    WeaponPickUp[] allPickups;

    public override void Update()
    {
        // Runs the base movement of the character
        base.Update();
        // If weapon is not equipped
        if (weaponUser.CurrentlyEquippedWeapon == null)
        {
            // Loop over all pickups in the game
            foreach (var pickup in allPickups)
            {
                //Get the weapon prefab that the pickup will give to the enemy
                var weapon = pickup.weapon.GetComponent<Weapon>();
                // Check if the weapon is a sniper rifle
                if (weapon is SniperRifle)
                {
                    // If the navagent on the enemy is enabled
                    if (navAgent.enabled)
                    {
                        //Make the nav mesh move to the sniper rifle
                        navAgent.SetDestination(pickup.transform.position);
                        break;
                    }
                }
                
            }
        }
        else
        {
            // Check if there is a player to target
            if (targetPlayer != null)
            {
                if (navAgent.enabled)
                {
                    //Make the nav mesh move to the target
                    navAgent.SetDestination(targetPlayer.transform.position);
                }
            }
        }
        // Check if there is a player to target
        if (targetPlayer != null)
        {
            // Causes enemy to look at player
            transform.LookAt(targetPlayer.transform.position);
            // Lock the x rotation so the enemy does not look up or down
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, transform.eulerAngles.z);
            //Get the velocity the nav mesh wants to move at
            Vector3 movementVector = navAgent.desiredVelocity;

            //Normalize the vector to a length of 1
            movementVector.Normalize();

            //Convert it from local-space coordinates to world-space coordinates so the animator can move in the correct direction


            movementVector.x *= Speed;
            movementVector.z *= Speed;
            // Sets the enemies movement to the navagents's desired velocity
            SetMovement(movementVector.x, movementVector.z);
            // If there is a weapon equipped
            if (weaponUser.CurrentlyEquippedWeapon != null)
            {
                // Shoot weapon towards target player
                weaponUser.ShootWeapon(targetPlayer.transform.position);
            }
        }
    }
    // Called when the enemy starts
    void Awake()
    {
        // Get navmesh component
        navAgent = GetComponent<NavMeshAgent>();
        // Get weaponUser component
        weaponUser = GetComponent<WeaponUser>();
        // Finds all pickups in the game
        allPickups = GameObject.FindObjectsOfType<WeaponPickUp>();
    }
    private void OnAnimatorMove()
    {
        // If the enemy has a navagent and an animator on him
        if (navAgent != null && animator != null)
        {
            // Set the navagent velocity to the animation's root motion velocity
            navAgent.velocity = animator.velocity;
        }
    }
    public void DestroyObject()
    {
        // Destroy object
        Destroy(gameObject);
    }
}
