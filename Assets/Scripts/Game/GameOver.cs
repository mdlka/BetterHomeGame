using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] AudioSource _clickSound;

    [Header("Load")]
    [SerializeField] LevelLoader _load;

    [Header("Save")]
    [SerializeField] private SaveAndLoad _save;

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    public void NewGame()
    {
        _clickSound.Play();

        Time.timeScale = 1f;
        _save.DeleteSave();
        _load.LoadLevel(1);
    }

    public void BackToMenu()
    {
        _clickSound.Play();

        Time.timeScale = 1f;
        _save.DeleteSave();
        _load.LoadLevel(0);
    }
}
