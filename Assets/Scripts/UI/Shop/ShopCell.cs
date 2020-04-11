using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopCell : MonoBehaviour, IPointerClickHandler
{
    public event Action Buying;

    [SerializeField] private Text _priceField;
    [SerializeField] private Image _iconField;


    public void Render(IFood food)
    {
        _priceField.text = food.Price.ToString();
        _iconField.sprite = food.UIIcon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Buying?.Invoke();
    }
}
