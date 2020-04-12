using System;
using System.IO;
using UnityEngine;

public class Load : MonoBehaviour
{
    [SerializeField] private Indicator _health;
    [SerializeField] private Indicator _energy;
    [SerializeField] private Indicator _food;
    [SerializeField] private Indicator _happy;
    [SerializeField] private Money _money;

    [SerializeField] private Transform _playerPosition;
    [SerializeField] private Fridge _fridge;

    [SerializeField] private SaveSystem _save;

    private void Start()
    {
        _health.SetValue(_save.GetHealth());
        _energy.SetValue(_save.GetEnergy());
        _food.SetValue(_save.GetFood());
        _happy.SetValue(_save.GetHappy());
        _money.SetValue(_save.GetMoney());

        _playerPosition.position = _save.GetPlayerPosition();

        AssetFood[] foods = _save.GetFoods();
        if(foods != null)
        {
            foreach (AssetFood food in foods)
            {
                _fridge.AddFood(food);
            }
        }
    }
}
