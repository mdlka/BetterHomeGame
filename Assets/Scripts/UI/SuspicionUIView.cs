using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspicionUIView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Scrollbar _suspicionValue;

    [SerializeField] private GameObject _gameOverPanel;

    private void OnEnable()
    {
        _player.SuspicionChanged += OnSuspicionChanged;

        OnSuspicionChanged(_player.Suspicion);
    }

    private void OnDisable()
    {
        _player.SuspicionChanged -= OnSuspicionChanged;
    }

    private void OnSuspicionChanged(float value)
    {
        _suspicionValue.size = value * 0.01f;

        if (value >= 100) _gameOverPanel.SetActive(true);
    }
}
