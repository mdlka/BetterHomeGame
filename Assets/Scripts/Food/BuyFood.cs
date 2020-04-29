using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyFood : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Money _money;
    [SerializeField] private Fridge _fridge;

    [Header("Sound")]
    [SerializeField] AudioSource _clickSound;

    public void Buy(AssetFood food, int price)
    {
        if (_money.Value - price >= 0)
        {
            if (_fridge.AddFood(food))
            {
                _clickSound.Play();
                _money.SetValue(_money.Value - price);
            }
        }        
    }
}
