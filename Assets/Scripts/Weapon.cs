using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    // Sets standard rate of fire
    [SerializeField]
    public float timeBetweenShots = 0f;

    // Shoots at target
    public abstract void Shoot(Vector3 target);
}
