using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyFood : MonoBehaviour
{
    [SerializeField] private Money _money;
    [SerializeField] private Fridge _fridge;

    public void Buy(AssetFood food, int price)
    {
        if (_money.Value - price >= 0)
        {
            if (_fridge.AddFood(food))
            {
                _money.SetValue(_money.Value - price);
            }
        }        
    }
}
