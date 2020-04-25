using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] private SaveSystem _save;

    public void BackToMenu()
    {
        _save.DeleteSave();
        SceneManager.LoadScene(0);
    }
}
