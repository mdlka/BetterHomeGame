using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private SaveSystem _save;

    public void NewGameButton()
    {
        _save.DeleteSave();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
