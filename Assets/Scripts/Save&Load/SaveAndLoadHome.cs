using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadHome : SaveAndLoad
{
    [SerializeField] private Indicator _health;
    [SerializeField] private Indicator _energy;
    [SerializeField] private Indicator _food;
    [SerializeField] private Indicator _happy;
    [SerializeField] private Money _money;

    [SerializeField] private Transform _playerPosition;
    [SerializeField] private Fridge _fridge;

    [SerializeField] private InteractionWithKnife _knife;
    [SerializeField] private QuarantineTimer _timer;

    [SerializeField] private SaveSystem _save;

    private void Start()
    {
        _health.SetValue(_save.GetHealth());
        _energy.SetValue(_save.GetEnergy());
        _food.SetValue(_save.GetFood());
        _happy.SetValue(_save.GetHappy());
        _money.SetValue(_save.GetMoney());

        _playerPosition.position = _save.GetPlayerPosition();

        _knife.SetKnifeInArm(_save.GetIsKnifeInArm());
        _timer.SetDay(_save.GetDay());

        AssetFood[] foods = _save.GetFoods();
        if (foods != null)
        {
            foreach (AssetFood food in foods)
            {
                _fridge.AddFood(food);
            }
        }
    }

    private void OnApplicationQuit()
    {
        SaveAll();
    }

    public override void SaveAll()
    {
        _save.SetGameExists(true);
        _save.SetIndicators(_health.Value, _energy.Value, _food.Value, _happy.Value, _money.Value);
        _save.SetPlayerPosition(_playerPosition.position);
        _save.SetFoods(_fridge.GetFoods());
        _save.SetIsKnifeInArm(_knife.GetKnifeInArm());
        _save.SetDay(_timer.Day);
        _save.SetScene(1);

        _save.SaveGame();
    }
}
