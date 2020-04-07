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
    [SerializeField] private Image _icon;

    public event Action<float> Chanded;

    public string Name => _name;
    public float Value => _value;
    public Image Icon => _icon;
}
