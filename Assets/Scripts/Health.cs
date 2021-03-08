using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    // Put health as a modifiable component in the inspector for current health
    [SerializeField]
    float health = 100f;
    // Put health as a modifiable component in the inspector for max health
    [SerializeField]
    float maxHealth = 100f;
   // Event that's triggered when health component starts
    [SerializeField]
    UnityEvent<float> OnStart;
    // Event that's triggered when health component heals
    [SerializeField]
    UnityEvent<float> OnHeal;
    // Event that's triggered when health component takes damage
    [SerializeField]
    UnityEvent<float> OnDamage;
    // Event that's triggered when health component dies
    [SerializeField]
    UnityEvent<float> OnDeath;
    
    public void Heal(float amount)
    {
        // How much we heal from health pick up
        health = health + amount;
        // Prevents health from exceeding max
        if (health > maxHealth)
        {
            // Health won't exceed max
            health = maxHealth;
        }
        // triggers the heal event
        OnHeal.Invoke(health);
    }

    public void Damage(float amount)
    {
        //Decrease the health
        health = health - amount;
        if (health < 0)
        {
            health = 0;
        }
        // Trigger damage event
        OnDamage.Invoke(health);
        // If health reaches 0 than player dies
        if (health == 0)
        {
            // trigger death event
            OnDeath.Invoke(health);
        }
    }
    void Start()
    {
        // Trigger start event
        OnStart.Invoke(health);
    }
}
