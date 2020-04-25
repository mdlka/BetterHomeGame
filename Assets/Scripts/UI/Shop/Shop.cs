using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<AssetFood> Foods;
    [SerializeField] private ShopCell _shopCellTemplate;
    [SerializeField] private Transform _container;
    [SerializeField] private BuyFood _buyFood;
    [SerializeField] private Prompt _prompt;

    private void Awake()
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
            ShopCell cell = Instantiate(_shopCellTemplate, _container);
            cell.Render(food);

            cell.Enter += () => _prompt.SetPromptValue((int)(food.Health * 100), (int)(food.Energy * 100),
                (int)(food.Food * 100), (int)(food.Happy * 100));

            cell.Buying += () => _buyFood.Buy(food, food.Price);
        });
    }
}
