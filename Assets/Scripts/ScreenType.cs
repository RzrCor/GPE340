using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenType : MonoBehaviour
{

    [SerializeField]
    Toggle toggle;

    private void Awake()
    {
        // If toggled on, makes game fullscreen
        toggle.isOn = Screen.fullScreen;
    }
    // Called when the toggle changes
    public void OnScreenModeChange(bool newValue)
    {
        // Sets new value for screen
        Screen.fullScreen = newValue;
    }
}
