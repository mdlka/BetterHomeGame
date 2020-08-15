using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _settingPanel;

    [Header("Sound")]
    [SerializeField] AudioSource _clickSound;

    [Header("Load")]
    [SerializeField] LevelLoader _load;

    [Header("Save")]
    [SerializeField] private SaveAndLoad _save;

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
        _clickSound.Play();

        Time.timeScale = 0;
        _pausePanel.SetActive(true);
        _isPaused = true;
    }

    public void BackToGame()
    {
        _clickSound.Play();

        Time.timeScale = 1;
        _pausePanel.SetActive(false);
        _isPaused = false;
    }

    public void Setting()
    {
        _clickSound.Play();
        _settingPanel.SetActive(true);
    }

    public void CloseSetting()
    {
        _clickSound.Play();
        _settingPanel.SetActive(false);
    }

    public void ExitToMenu()
    {
        _clickSound.Play();

        _save.SaveAll();
        _load.LoadLevel(0);
    }
}
