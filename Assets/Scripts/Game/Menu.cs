using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _aboutGamePanel;
    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private SaveSystem _save;

    public void OpenAboutGame()
    {
        _aboutGamePanel.SetActive(true);
    }

    public void CloseAboutGame()
    {
        _aboutGamePanel.SetActive(false);
    }

    public void ContinueGame()
    {
        if(_save.GetGameExists())
        {
            SceneManager.LoadScene(_save.GetScene());
        }
    }

    public void NewGame()
    {
        _save.DeleteSave();
        SceneManager.LoadScene(1);
    }

    public void OpenSetting()
    {
        _settingPanel.SetActive(true);
    }

    public void CloseSetting()
    {
        _settingPanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
