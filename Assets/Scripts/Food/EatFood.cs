using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFood : MonoBehaviour
{
    [Header("Indicators")]
    [SerializeField] private IndicatorsChange _indicatorsChange;

    [Header("Sound")]
    [SerializeField] AudioSource _eatSound;
    [SerializeField] AudioClip _food;
    [SerializeField] AudioClip _water;

    public void Eat(float health, float energy, float food, float happy, bool isWater)
    {
        if (isWater) _eatSound.PlayOneShot(_water);
        else _eatSound.PlayOneShot(_food);

        _indicatorsChange.SetHealthValue(health);
        _indicatorsChange.SetEnergyValue(energy);
        _indicatorsChange.SetFoodValue(food);
        _indicatorsChange.SetHappyValue(happy);
    }
}
