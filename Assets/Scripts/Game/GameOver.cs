using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private SaveSystem _save;

    public void NewGame()
    {
        _save.DeleteSave();
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        _save.DeleteSave();
        SceneManager.LoadScene(0);
    }
}
