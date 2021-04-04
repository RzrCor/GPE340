using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Stores original speed
    float originalSpeed;
    // How fast the player is moving
    [SerializeField]
    protected float Speed = 3f;
    // How long speed pickup lasts
    [SerializeField]
    float speedUpTime = 15f;
    // Timer to keep track of the speed pickup
    float _speedTimer;
    // Variable to allow us to animate the player model
    protected Animator animator;
    // Bool to figure out if the player is touching the ground or not
    protected bool OnGround;
    // Variable to give additional control over the player model's rigidbody
    protected new Rigidbody rigidbody;
    // Variable to control how high a character can jump
    public Vector3 jumpForce;
    // The health component on the character
    Health characterHealth;

    // Start is called before the first frame update
    void Start()
    {
        // At start it pulls the animator for player model
        animator = GetComponent<Animator>();
        // At start it pulls the rigidbody of the player model
        rigidbody = GetComponent<Rigidbody>();
        // gets the health component
        characterHealth = GetComponent<Health>();
    }



    // Update is called once per frame
    public virtual void Update()
    {              
        animator.SetBool("onGround", OnGround);
        // Starts timer for speed pickup duration if it's above 0
        if (_speedTimer > 0f)
        {
            // Causes timer to countdown
            _speedTimer -= Time.deltaTime;
            // Checks if timer is less than or equal to 0
            if (_speedTimer <= 0f)
            {
                // Returns speed to normal
                Speed = originalSpeed;
            }
        }
        // If speed is less than or equal to 3
        if (Speed <= 3f)
        {
            // Keep speed as normal
            animator.speed = 1f;
        }
        // If speed is greater than 3
        else if (Speed > 3f)
        {
            // Make the animation go faster
            animator.speed = Speed / 3f;
        }
    }

    public void SetSpeed(float newSpeed)
    {
        // Store original speed for later
        originalSpeed = Speed;
        // Set the new speed
        Speed = newSpeed;
        // Start the speed timer
        _speedTimer = speedUpTime;
    }
    void OnCollisionEnter(Collision collision)
    {
        // Register if player is on the layer "ground"
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            // Registers that the player is touching the ground
            OnGround = true;
            // Enables root motion to make sure it doesn't interfere with player movement
            animator.applyRootMotion = true;
        }
        // Gets Lava component
        var lava = collision.gameObject.GetComponent<Lava>();
        // If the object we collided with has a lava component on it
        if (lava != null)
        {
            // Character takes damage
            characterHealth.Damage(lava.Damage);
        }
    }

    public void SetMovement(float horizontal, float vertical)
    {
        Vector3 movementVector = new Vector3(horizontal, 0f, vertical);
        // Code block for OnGround bool
        if (OnGround)
        {
            // Makes sure player moves in global directions
            movementVector = transform.InverseTransformDirection(movementVector);
            animator.SetFloat("Horizontal", movementVector.x);
            animator.SetFloat("Vertical", movementVector.z);
        }
        else
        {
            // Keeps the player moving in the direction they entered when jumping
            movementVector.y = rigidbody.velocity.y;
            rigidbody.velocity = movementVector;
        }
    }


}
