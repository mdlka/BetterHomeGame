using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _aboutGamePanel;
    [SerializeField] private GameObject _settingPanel;

    [Header("Sound")]
    [SerializeField] AudioSource _clickSound;

    [Header("Save")]
    [SerializeField] private SaveAndLoadMenu _saveMenu;
    [SerializeField] private SaveSystem _save;

    public void OpenAboutGame()
    {
        _clickSound.Play();
        _aboutGamePanel.SetActive(true);
    }

    public void CloseAboutGame()
    {
        _clickSound.Play();
        _aboutGamePanel.SetActive(false);
    }

    public void ContinueGame()
    {
        _clickSound.Play();

        if (_save.GetGameExists())
        {
            SceneManager.LoadScene(_save.GetScene());
        }
    }

    public void NewGame()
    {
        _clickSound.Play();

        _save.DeleteSave();
        SceneManager.LoadScene(1);
    }

    public void OpenSetting()
    {
        _clickSound.Play();
        _settingPanel.SetActive(true);
    }

    public void CloseSetting()
    {
        _clickSound.Play();

        _settingPanel.SetActive(false);
        _saveMenu.SaveAll();
    }

    public void Exit()
    {
        _clickSound.Play();
        Application.Quit();
    }
}
