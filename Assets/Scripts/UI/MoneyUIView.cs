using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUIView : MonoBehaviour
{
    [SerializeField] private Money _money;
    [SerializeField] private Text _value;
    [SerializeField] private Image _sprite;

    private void OnEnable()
    {
        _money.Chanded += OnMoneyChanged;

        _sprite.sprite = _money.Icon;

        OnMoneyChanged(_money.Value);
    }

    private void OnDisable()
    {
        _money.Chanded -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int value)
    {
        _value.text = value.ToString();
    }
}
