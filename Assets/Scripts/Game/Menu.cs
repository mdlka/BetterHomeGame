using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _aboutGamePanel;
    [SerializeField] private GameObject _settingPanel;

    [Header("Sound")]
    [SerializeField] AudioSource _clickSound;

    [Header("Load")]
    [SerializeField] LevelLoader _load;

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
            _load.LoadLevel(_save.GetScene());
        }
    }

    public void NewGame()
    {
        _clickSound.Play();

        _save.DeleteSave();
        _load.LoadLevel(1);
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
