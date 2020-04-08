using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorsChange : MonoBehaviour
{
    [SerializeField] private Indicator _health;
    [SerializeField] private Indicator _energy;
    [SerializeField] private Indicator _food;
    [SerializeField] private Indicator _happy;

    public void SetHealthValue(float value)
    {
        _health.SetValue(_health.Value + value);
    }

    public void SetEnergyValue(float value)
    {
        _energy.SetValue(_energy.Value + value);
    }

    public void SetFoodValue(float value)
    {
        _food.SetValue(_food.Value + value);
    }

    public void SetHappyValue(float value)
    {
        _happy.SetValue(_happy.Value + value);
    }
}
