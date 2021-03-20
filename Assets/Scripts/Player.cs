using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    // The component for the player to use weapons
    WeaponUser weaponUser;


    public override void Update()
    {
        // Runs the base move speed
        base.Update();

        // Reads the horizonal position of the player model
        var horizontal = Input.GetAxis("Horizontal");
        // Reads the vertical position of the player model
        var vertical = Input.GetAxis("Vertical");
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
            // Look at where mouse is
            transform.LookAt(pointToLookAt);
        }
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

    private void Awake()
    {
        // get weaponUser component
        weaponUser = GetComponent<WeaponUser>();
    }
    public void DestroyObject()
    {
        // Destroy object
        Destroy(gameObject);
    }
}
