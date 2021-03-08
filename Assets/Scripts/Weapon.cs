using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    // Shoots at target
    public abstract void Shoot(Vector3 target);
}
