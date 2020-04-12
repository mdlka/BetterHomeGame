using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Money", order = 152)]
public class Money : ScriptableObject
{
    [SerializeField] private int _value;
    [SerializeField] private Sprite _icon;

    public event Action<int> Chanded;

    public int Value => _value;
    public Sprite Icon => _icon;

    private void UpdateMoneyValue()
    {
        Chanded?.Invoke(_value);
    }

    public void SetValue(int value)
    {
        _value = value;
        _value = Mathf.Clamp(_value, 0, 99999);
        UpdateMoneyValue();
    }
}
