using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Scrollbar _healthValue;

    [SerializeField] private GameObject _gameOverPanel;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;

        OnHealthChanged(_player.Health);
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        _healthValue.size = value * 0.01f;

        if (value == 0) _gameOverPanel.SetActive(true);
    }
}
