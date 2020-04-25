using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopCell : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    public event Action Buying;
    public event Action Enter;

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        Enter?.Invoke();
    }
}
