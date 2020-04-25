using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    [SerializeField] private SaveSystem _save;

    public void DeleteGameSave()
    {
        _save.DeleteSave();
        SceneManager.LoadScene(0);
    }
}
