using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadLaboratory : SaveAndLoad
{
    [SerializeField] private Player _player;
    [SerializeField] private Gun _gun;

    [SerializeField] private SaveSystem _save;

    private void Start()
    {
        _player.SetHaveGun(_save.GetHaveGun());
        _gun.SetAmmoValue(_save.GetAmmoValue());
    }

    private void OnApplicationQuit()
    {
        SaveAll();
    }

    public override void SaveAll()
    {
        _save.SetGameExists(true);
        _save.SetHaveGun(_player.GetHaveGun());
        _save.SetScene(3);

        _save.SaveGame();
    }
}
