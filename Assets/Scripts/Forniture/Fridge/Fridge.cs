using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

            Sort(_container);

            cell.Eating += () => Destroy(cell.gameObject);
            cell.Eating += () => _eatFood.Eat(food.Health, food.Energy, food.Food, food.Happy);
        });
    }

    private void Sort(Transform container)
    {
        List<Transform> children = container.GetComponentInChildren<Transform>(true).Cast<Transform>().ToList();

        children.Sort((Transform t1, Transform t2) => 
        {
            return t1.name.CompareTo(t2.name);
        });

        for (int i = 0; i < children.Count; ++i)
        {
            children[i].SetSiblingIndex(i);
        }
    }
}
