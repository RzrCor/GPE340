using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RagdollManager : MonoBehaviour
{
    // List of all ragdoll colliders
    [SerializeField]
    Collider[] ragdollColliders;
    // List of all ragdoll rigidbodies
    [SerializeField]
    Rigidbody[] ragdollRigidbodies;
    // Main rigidbody on the enemy
    [SerializeField]
    Rigidbody mainRigidbody;
    // main collider on the enemy
    [SerializeField]
    Collider mainCollider;
    // Main animator on the enemy
    [SerializeField]
    Animator mainAnimator;
    // Main navagent on the enemy
    [SerializeField]
    NavMeshAgent mainNavAgent;
    // Time before enemy destroys itself
    [SerializeField]
    float destroyTime;

    public void DoRagdoll()
    {
        // Foe each collider in ragdoll colliders
        foreach (var collider in ragdollColliders)
        {
            // Enable all ragdoll colliders
            collider.enabled = true;
        }
        // For each rigidbody in ragdoll rigidbodies
        foreach (var rigidbody in ragdollRigidbodies)
        {
            // enables gravity on all rigidbodies
            rigidbody.isKinematic = false;
        }
        // disables enemy's main collider
        mainCollider.enabled = false;
        // disables gravity on enemy's main rigidbody
        mainRigidbody.isKinematic = true;
        // disables enemy's animator
        mainAnimator.enabled = false;
        // disables enemy's navagent
        mainNavAgent.enabled = false;
        // Destroy game object after set time
        Destroy(gameObject, destroyTime);
    }
}
