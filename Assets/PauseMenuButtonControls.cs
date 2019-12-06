using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtonControls : MonoBehaviour
{ 

    //Restart, this will restart the current map
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    //Main Menu, this will load the main menu back up
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadSceneAsync(0); //load the main menu scene
    }

    //Exit Game, this will quit the entire game and go back to desktop
    public void ExitGame()
    {
        Application.Quit();
    }

    //Continue, this will unpause the game
    public void Continue()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
