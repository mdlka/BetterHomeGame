using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorsPlayer : MonoBehaviour
{
    [Header("Indicator bars")]
    [SerializeField] private Scrollbar _healthBar;
    [SerializeField] private Scrollbar _energyBar;
    [SerializeField] private Scrollbar _foodBar;
    [SerializeField] private Scrollbar _funBar;

    [Header("Add to indicators")]
    [SerializeField] [Range(-0.99f, 0.99f)] private float _healthAdded = -0.01f;
    [SerializeField] [Range(-0.99f, 0.99f)] private float _energyAdded = -0.01f;
    [SerializeField] [Range(-0.99f, 0.99f)] private float _foodAdded = -0.01f;
    [SerializeField] [Range(-0.99f, 0.99f)] private float _funAdded = -0.01f;

    private float _defaultHealthAdded;
    private float _defaultEnergyAdded;
    private float _defaultFoodAdded;
    private float _defaultFunAdded;

    private IEnumerator _healthCoroutine;
    private IEnumerator _energyCoroutine;
    private IEnumerator _foodCoroutine;
    private IEnumerator _funCoroutine;

    private void Awake()
    {
        _defaultHealthAdded = _healthAdded;
        _defaultEnergyAdded = _energyAdded;
        _defaultFoodAdded = _foodAdded;
        _defaultFunAdded = _funAdded;
    }

    private void Start()
    {
        _energyCoroutine = Indicators(_energyAdded, _energyBar);
        _foodCoroutine = Indicators(_foodAdded, _foodBar);
        _funCoroutine = Indicators(_funAdded, _funBar);

        StartCoroutine(_energyCoroutine);
        StartCoroutine(_foodCoroutine);
        StartCoroutine(_funCoroutine);
    }

    IEnumerator Indicators(float amountOfAdded, Scrollbar indicator)
    {
        indicator.size += amountOfAdded;

        yield return new WaitForSeconds(3);

        if (indicator.size > 0.01f)
            StartCoroutine(Indicators(amountOfAdded, indicator));
    }

    public void SubtractionFromHealth(float amount)
    {
        _healthBar.size -= amount;
    }

    public void AddingToHealth(float amount)
    {
        _healthBar.size += amount;
    }
}
