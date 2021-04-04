using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    // The mixer that contains the channels
    [SerializeField]
    AudioMixer mixer;
    // The parameter for setting the volume
    [SerializeField]
    string parameterName;
    // The slider for current volume channel
    [SerializeField]
    Slider slider;
    // Name for storing the volume to disc
    [SerializeField]
    string PlayerPrefName;

    void Start()
    {
        // Get the volume that is currently on the mixer
        float volume = 0f;
        mixer.GetFloat(parameterName, out volume);
        // Sets the slider value to the current volume
        slider.value = volume;
    }
    // Called when the slider changes
    public void OnSliderChange(float value)
    {
        // Sets the volume on the mixer to the slider value
        mixer.SetFloat(parameterName, value);
        // Stores the volume to disc
        PlayerPrefs.SetFloat(PlayerPrefName, value);
    }
}
