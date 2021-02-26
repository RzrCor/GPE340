using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    Animator animator;
    bool OnGround;
    Rigidbody rigidbody;
    // Variable to control how high a character can jump
    public Vector3 jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        horizontal *= 3f;
        vertical *= 3f;
        Vector3 movementVector = new Vector3(horizontal, 0f, vertical);
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
        // Creates an imaginary plane to register the mouse
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        // Fires the ray at the plane
        // Ray starts at camera and points to the world
        if (plane.Raycast(ray, out distance))
        {
            Vector3 pointToLookAt = ray.GetPoint(distance);
            transform.LookAt(pointToLookAt);
        }
        // Allows the player to jump
        if (Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            animator.Play("Rifle Jump");
            // Registers if character is on ground
            OnGround = false;
            // Disable root motion to make sure it doesn't interfere with player movement
            animator.applyRootMotion = false;
            rigidbody.AddForce(jumpForce, ForceMode.Impulse);
        }
        animator.SetBool("onGround", OnGround);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Register if player is on the layer "ground"
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            OnGround = true;
            animator.applyRootMotion = true;
        }
    }
}
