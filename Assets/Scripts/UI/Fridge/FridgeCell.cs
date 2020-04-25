using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FridgeCell : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    public event Action Eating;
    public event Action Enter;

    [SerializeField] private Text _nameField;
    [SerializeField] private Image _iconField;

    public void Render(IFood food)
    {
        _nameField.text = food.Name;
        _iconField.sprite = food.UIIcon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Eating?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Enter?.Invoke();
    }
}
