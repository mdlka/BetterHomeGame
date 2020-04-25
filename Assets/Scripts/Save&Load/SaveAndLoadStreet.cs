using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadStreet : SaveAndLoad
{
    [SerializeField] private SaveSystem _save;

    private void Start()
    {
        
    }

    private void OnApplicationQuit()
    {
        SaveAll();
    }

    public override void SaveAll()
    {
        _save.SetGameExists(true);
        _save.SetScene(2);

        _save.SaveGame();
    }
}
