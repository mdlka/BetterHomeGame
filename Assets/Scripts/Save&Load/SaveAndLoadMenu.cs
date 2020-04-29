using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadMenu : SaveAndLoad
{
    [SerializeField] private Setting _setting;
    [SerializeField] private SaveSystem _save;

    private void Start()
    {
        _setting.SetPostProcess(_save.GetPostProcess());
        _setting.SetMusicVolume(_save.GetMusicVolume());
        _setting.SetSoundVolume(_save.GetSoundVolume());
    }

    private void OnApplicationQuit()
    {
        SaveAll();
    }

    public override void SaveAll()
    {
        _save.SetPostProcess(_setting.GetPostProcess());
        _save.SetMusicVolume(_setting.GetMusicVolume());
        _save.SetSoundVolume(_setting.GetSoundVolume());

        _save.SaveGame();
    }

    public override void DeleteSave()
    {
        SaveAll();
        _save.DeleteSave();
    }
}
