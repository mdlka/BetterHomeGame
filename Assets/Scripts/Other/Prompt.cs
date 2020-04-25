using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prompt : MonoBehaviour
{
    [Header("Value")]
    [SerializeField] private int _healthValue;
    [SerializeField] private int _energyValue;
    [SerializeField] private int _foodValue;
    [SerializeField] private int _happyValue;

    [Header("Text")]
    [SerializeField] private Text _health;
    [SerializeField] private Text _energy;
    [SerializeField] private Text _food;
    [SerializeField] private Text _happy;

    private void Awake()
    {
        _health.text = _healthValue.ToString();
        _energy.text = _energyValue.ToString();
        _food.text = _foodValue.ToString();
        _happy.text = _happyValue.ToString();
    }

    public void SetPromptValue(int health, int energy, int food, int happy)
    {
        _health.text = health.ToString();
        _energy.text = energy.ToString();
        _food.text = food.ToString();
        _happy.text = happy.ToString();
    }
}
