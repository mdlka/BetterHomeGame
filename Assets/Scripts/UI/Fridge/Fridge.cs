using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    [SerializeField] private List<AssetFood> Foods;
    [SerializeField] private FridgeCell _fridgeCellTemplate;
    [SerializeField] private Transform _container;
    [SerializeField] private EatFood _eatFood;

    public void OnEnable()
    {
        Render(Foods);
    }

    public void Render(List<AssetFood> foods)
    {
        foreach (Transform child in _container)
        {
            Destroy(child.gameObject);
        }

        foods.ForEach(food =>
        {
            FridgeCell cell = Instantiate(_fridgeCellTemplate, _container);
            cell.Render(food);

            cell.gameObject.name = food.Name;

            cell.Eating += () => Destroy(cell.gameObject);
            cell.Eating += () => _eatFood.Eat(food.Health, food.Energy, food.Food, food.Happy);
        });
    }
}
