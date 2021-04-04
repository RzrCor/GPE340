using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResolutionDropdown : MonoBehaviour
{

    [SerializeField]
    TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Awake()
    {

        resolutions = Screen.resolutions;

        var resolutionIndex = Array.IndexOf(resolutions, Screen.currentResolution);

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        foreach (var res in resolutions)
        {
            options.Add(res.ToString());
        }

        resolutionDropdown.AddOptions(options);

        resolutionDropdown.value = resolutionIndex;
    }

    public void OnResolutionChange(int index)
    {
        var resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode, resolution.refreshRate);
    }
}
