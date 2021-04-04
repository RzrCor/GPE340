using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSetter : MonoBehaviour
{
    // Allows access to the mixer
    [SerializeField]
    AudioMixer mixer;
    // The name of the exposed parameter for the master volume
    [SerializeField]
    string masterParameterName;
    // The name of the exposed parameter for the music volume
    [SerializeField]
    string musicParameterName;
    // The name of the exposed parameter for the sound fx volume
    [SerializeField]
    string soundFXParameterName;
    private void Start()
    {
        // Gets the master audio stored on disc
        var storedMasterVolume = PlayerPrefs.GetFloat("MasterAudio");
        // Sets the volume that was stored on disc
        mixer.SetFloat(masterParameterName, storedMasterVolume);
        // Gets the music audio stored on disc
        var storedMusicVolume = PlayerPrefs.GetFloat("MusicAudio");
        // Sets the volume that was stored on disc
        mixer.SetFloat(musicParameterName, storedMusicVolume);
        // Gets the sound fx audio stored on disc
        var storedSoundFXVolume = PlayerPrefs.GetFloat("SoundFXAudio");
        // Sets the volume that was stored on disc
        mixer.SetFloat(soundFXParameterName, storedSoundFXVolume);
    }

    void OnApplicationQuit()
    {
        // Gets the master volume currently on mixer
        float masterVolume = 0;
        mixer.GetFloat(masterParameterName, out masterVolume);
        // Stores the master volume to disc
        PlayerPrefs.SetFloat("MasterAudio", masterVolume);
        // Gets the music volume currently on mixer
        float musicVolume = 0;
        mixer.GetFloat(musicParameterName, out musicVolume);
        // Stores the music volume to disc
        PlayerPrefs.SetFloat("MusicAudio", musicVolume);
        // Gets the sound fx volume currently on mixer
        float soundFXVolume = 0;
        mixer.GetFloat(soundFXParameterName, out soundFXVolume);
        // Stores the sound fx volume to disc
        PlayerPrefs.SetFloat("SoundFXAudio", soundFXVolume);
        // Saves the sound settings
        PlayerPrefs.Save();
    }
}
