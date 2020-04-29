using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SaveAndLoadStreet : SaveAndLoad
{
    [SerializeField] private Player _player;
    [SerializeField] private Gun _gun;

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
        _save.SetGameExists(true);
        _save.SetAmmoValue(_gun.AmmoValue);
        _save.SetHaveGun(_player.GetHaveGun());
        _save.SetScene(2);
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
