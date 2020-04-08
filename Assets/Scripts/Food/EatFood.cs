using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFood : MonoBehaviour
{
    [SerializeField] private IndicatorsChange _indicatorsChange;


    public void Eat(float health, float energy, float food, float happy)
    {
        _indicatorsChange.SetHealthValue(health);
        _indicatorsChange.SetEnergyValue(energy);
        _indicatorsChange.SetFoodValue(food);
        _indicatorsChange.SetHappyValue(happy);
    }
}
