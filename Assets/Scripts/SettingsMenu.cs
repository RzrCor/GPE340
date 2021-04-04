using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

    [SerializeField]
    GameObject Activator;

    public void ShowSettingsMenu()
    {
        // Shows settings menu
        Activator.SetActive(true);
    }

    public void HideSettingsMenu()
    {
        // Hides settings menu
        Activator.SetActive(false);
    }
}
