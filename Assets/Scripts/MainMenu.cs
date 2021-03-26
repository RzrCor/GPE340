using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Loads the Game Scene
        SceneManager.LoadScene("Game Scene");
    }
    public void QuitGame()
    {
        // Quits game
        Application.Quit();
    }
}
