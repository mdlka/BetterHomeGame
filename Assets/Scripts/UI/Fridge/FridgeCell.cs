using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FridgeCell : MonoBehaviour, IPointerClickHandler
{
    public event Action Eating;

    [SerializeField] private Text _nameField;
    [SerializeField] private Image _iconField;


    public void Render(IFood food)
    {
        _nameField.text = food.Name;
        _iconField.sprite = food.UIIcon;
    }

    private void Eat()
    {
        Eating?.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Eat();
    }
}
