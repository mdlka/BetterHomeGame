using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    private bool _isPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused == false) PauseGame();
            else BackToGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        _pausePanel.SetActive(true);
        _isPaused = true;
    }

    public void BackToGame()
    {
        Time.timeScale = 1;
        _pausePanel.SetActive(false);
        _isPaused = false;
    }

    public void Setting()
    {

    }

    public void ExitToMenu()
    {
        Application.Quit();
    }
}
