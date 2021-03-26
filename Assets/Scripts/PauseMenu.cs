using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // The singleton for accessing the pause menu anywhere
    public static PauseMenu Singleton;
    // Bool for if game is paused
    public bool GamePaused = false;
    // The object for showing and hiding the pause menu
    [SerializeField]
    GameObject Activator;


    void Awake()
    {
        // Sets the singleton so it can be accessed anywhere
        Singleton = this;
    }

    public void PauseGame()
    {
        // Enables activator
        Activator.SetActive(true);
        // Pauses game
        GamePaused = true;
        // Pauses time
        Time.timeScale = 0f;
    }

    public void UnPauseGame()
    {
        // Disables activator
        Activator.SetActive(false);
        // Unpauses game
        GamePaused = false;
        // restores time to normal
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        // restores time to normal
        Time.timeScale = 1f;
        // Quits to main menu
        SceneManager.LoadScene("Main Menu");
    }

    void Update()
    {
        // If escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape) && GamePaused == false)
        {
            // Pauses game if key is pressed
            PauseGame();
        }
    }
}
