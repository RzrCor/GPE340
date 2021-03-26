using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponUI : MonoBehaviour
{
    TextMeshProUGUI textComponent;

    void Awake()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }
    // Changes health UI to display current health
    public void UpdateWeaponDisplay(Weapon weapon)
    {
        textComponent.text = "Weapon equipped = " + weapon.gameObject.name;
    }
}
