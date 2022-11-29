using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    
    public void StratGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        // Quit the game
        Application.Quit();
    }
}
