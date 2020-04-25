using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorsUIView : MonoBehaviour
{
    [SerializeField] private Indicator _indicator;
    [SerializeField] private Scrollbar _scrollBar;
    [SerializeField] private Text _value;
    [SerializeField] private Image _sprite;

    private void OnEnable()
    {
        _indicator.Chanded += OnIndicatorChanged;

        _sprite.sprite = _indicator.Icon;

        OnIndicatorChanged(_indicator.Value);
    }

    private void OnDisable()
    {
        _indicator.Chanded -= OnIndicatorChanged;
    }

    private void OnIndicatorChanged(float value)
    {
        _scrollBar.size = value;
        _value.text = string.Format("{0:0}%", value * 100);
    }
}
