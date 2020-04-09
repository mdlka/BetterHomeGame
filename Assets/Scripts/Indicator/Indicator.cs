using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Indicator", order = 151)]
public class Indicator : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private float _value;
    [SerializeField] private Sprite _icon;

    public event Action<float> Chanded;

    public string Name => _name;
    public float Value => _value;
    public Sprite Icon => _icon;

    private void UpdateIndicatorValue()
    {
        Chanded?.Invoke(_value);
    }

    public void SetValue(float value)
    {
        _value = value;
        _value = Mathf.Clamp(_value, 0f, 1f);
        UpdateIndicatorValue();
    }
}
