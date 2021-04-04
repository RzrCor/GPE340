using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    [SerializeField]
    GameObject Activator;

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

    
    public void ShowMainMenu()
    {
        // Shows main menu
        Activator.SetActive(true);
    }

    public void HideMainMenu()
    {
        // Hides main menu
        Activator.SetActive(false);
    }
}
