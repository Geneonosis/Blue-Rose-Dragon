using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInGameCommands : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
