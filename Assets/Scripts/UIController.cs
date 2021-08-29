using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class UIController : MonoBehaviour
{

    bool isGamePaused;

    public bool GameStatus()
    {
        return isGamePaused;
    }

    public void PauseGame()
    {
        if (isGamePaused)
        {
  
            isGamePaused = false;
            Time.timeScale = 1;
        }
        else
        {
            isGamePaused = true;
            Time.timeScale = 0;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
