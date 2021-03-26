using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Character
{
    // The component for the player to use weapons
    WeaponUser weaponUser;
    // Lives player starts with
    [SerializeField]
    int lives = 3;
    // Stores starting position
    Vector3 startingPosition;
    // Allows access to the health component
    Health health;
    // The on lives lost event
    [SerializeField]
    UnityEvent<int> OnLivesLost;
    // The player singleton
    public static Player Singleton;
    public override void Update()
    {
        // Runs the base move speed
        base.Update();
        // Sets movement
        float horizontal = 0f;
        float vertical = 0f;
        //  If game is not paused
        if (PauseMenu.Singleton.GamePaused == false)
        {
            //Reads the horizonal position of the player model
            horizontal = Input.GetAxis("Horizontal");
            // Reads the vertical position of the player model
            vertical = Input.GetAxis("Vertical");
        }
        // Increases input of direction to 3 to help animator understand what animation to play
        horizontal *= Speed;
        vertical *= Speed;
        // Sets the player's movement to the horizontal and vertical inputs
        SetMovement(horizontal, vertical);

        // Creates an imaginary plane to register the mouse
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        // Fires the ray at the plane
        // Ray starts at camera and points to the world
        if (plane.Raycast(ray, out distance))
        {
            // Get the position where the mouse landed
            Vector3 pointToLookAt = ray.GetPoint(distance);
            if (PauseMenu.Singleton.GamePaused == false)
            {
                // Look at where mouse is
                transform.LookAt(pointToLookAt);
            }
            
        }

        if (PauseMenu.Singleton.GamePaused == false)
        {
            // Allows the player to jump
            if (Input.GetKeyDown(KeyCode.Space) && OnGround)
            {
                // Plays rifle jump animation
                animator.Play("Rifle Jump");
                // Registers that the player is not touching the ground
                OnGround = false;
                // Disable root motion to make sure it doesn't interfere with player movement
                animator.applyRootMotion = false;
                rigidbody.AddForce(jumpForce, ForceMode.Impulse);
            }

            if (Input.GetMouseButton(0))
            {
                // Create a ray that starts at the mouse position
                Ray gunRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                // Stores the results of the raycast
                RaycastHit hit;
                // Fires the ray at the world
                // Ray starts at camera and points to the world
                if (Physics.Raycast(gunRay, out hit))
                {
                    // Shoot weapon
                    weaponUser.ShootWeapon(hit.point);
                }
            }
        }
    }

    private void Awake()
    {
        // get weaponUser component
        weaponUser = GetComponent<WeaponUser>();
        // Where ever the player starts, that is the starting position
        startingPosition = transform.position;
        // Calls the health component
        health = GetComponent<Health>();
        // Sets the singleton so the player can be accessed from anywhere
        Singleton = this;
    }
    public void DestroyObject()
    {
        // Reduces life count
        lives = lives - 1;
        // Calls the on lives lost event
        if (OnLivesLost != null)
        {
            OnLivesLost.Invoke(lives);
        }
        // If lives = 0
        if (lives == 0)
        {
            // Destroy object
            Destroy(gameObject);
        }
        else
        {
            // Respawns player at starting position
            transform.position = startingPosition;
            // Respawns player with max health
            health.Heal(health.maxHealth);
        }

    }
}
