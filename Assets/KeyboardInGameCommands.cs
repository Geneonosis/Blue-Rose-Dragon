using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInGameCommands : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private void Start()
    {
        Time.timeScale = 1;
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
