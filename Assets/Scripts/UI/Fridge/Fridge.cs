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
    [SerializeField] private Prompt _prompt;

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

            cell.Enter += () => _prompt.SetPromptValue((int)(food.Health * 100), (int)(food.Energy * 100),
                (int)(food.Food * 100), (int)(food.Happy * 100));

            cell.Eating += () => Destroy(cell.gameObject);
            cell.Eating += () => foods.Remove(food);
            cell.Eating += () => _eatFood.Eat(food.Health, food.Energy, food.Food, food.Happy, food.isWater);
        });
    }

    public bool AddFood(AssetFood food)
    {
        if(Foods.Count < 16)
        {
            Foods.Add(food);
            return true;
        }

        return false;
    }

    public AssetFood[] GetFoods()
    {
        return Foods.ToArray();
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
