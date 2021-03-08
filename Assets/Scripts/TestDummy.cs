using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDummy : MonoBehaviour
{
    public void OnHealthDeath(float health)
    {
        // Destroys object when health runs out
        Destroy(gameObject);
    }
}
