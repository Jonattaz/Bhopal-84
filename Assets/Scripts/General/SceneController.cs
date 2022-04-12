using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject menu;
    public GameObject buttons;

  // Load another scenes
    public void SceneLoad(int Scene)

    {
        SceneManager.LoadScene(Scene);
    }

    // Allows the player to exit the game
    public void ExitGame()
    {
        Application.Quit();
    }

    public void MenuToButtons() {
        buttons.SetActive(true);
        menu.SetActive(false);
    }

    
    public void ButtonsToMenu() {
        buttons.SetActive(false);
        menu.SetActive(true);
    }
}
