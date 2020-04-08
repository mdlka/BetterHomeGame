using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorsUpdate : MonoBehaviour
{
    [SerializeField] private Indicator[] _indicators;
    [SerializeField] [Range(0f, 0.1f)] private float _value;

    private void Awake()
    {
        foreach (Indicator indicator in _indicators)
        {
            StartCoroutine(DecreasingIndicatorValue(indicator, _value));
        }
    }

    IEnumerator DecreasingIndicatorValue(Indicator indicator, float value)
    {
        indicator.SetValue(indicator.Value - value);

        yield return new WaitForSeconds(3);

        if (indicator.Value > 0f)
            StartCoroutine(DecreasingIndicatorValue(indicator, value));
    }
}
