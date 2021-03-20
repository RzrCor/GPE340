using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    TextMeshProUGUI textComponent;

    void Awake()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }
    // Changes health UI to display current health
    public void UpdateHealthDisplay(float health)
    {
        textComponent.text = "Health = " + health;
    }
}
