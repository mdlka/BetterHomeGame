using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] AudioSource _clickSound;

    [Header("Save")]
    [SerializeField] private SaveAndLoad _save;

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    public void BackToMenu()
    {
        _clickSound.Play();

        Time.timeScale = 1f;
        _save.DeleteSave();
        SceneManager.LoadScene(0);
    }
}
