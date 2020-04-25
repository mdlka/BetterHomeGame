using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuarantineTimerUIView : MonoBehaviour
{
    [SerializeField] private QuarantineTimer _timer;
    [SerializeField] private Text _dayText;
    [SerializeField] private GameObject _winPanel;

    private void OnEnable()
    {
        _timer.Changed += OnDayChanged;

        OnDayChanged(_timer.Day);
    }

    private void OnDisable()
    {
        _timer.Changed -= OnDayChanged;
    }

    private void OnDayChanged(int value)
    {
        if (value > 0)
        {
            _dayText.text = $"Дней до конца карантина: {_timer.Day}";
            StartCoroutine(NewDay());
        }
        else if (value == 0)
        {
            _winPanel.SetActive(true);
        }
    }

    IEnumerator NewDay()
    {
        _dayText.gameObject.SetActive(true);
        
        StartCoroutine(Blackout());

        yield return new WaitForSeconds(3f);

        StartCoroutine(Lighting());
    }

    IEnumerator Blackout()
    {
        _dayText.color = new Color(_dayText.color.r, _dayText.color.g, _dayText.color.b, _dayText.color.a + 0.01f);
        yield return new WaitForSeconds(0.01f);
        if (_dayText.color.a < 1) StartCoroutine(Blackout());
    }

    IEnumerator Lighting()
    {
        _dayText.color = new Color(_dayText.color.r, _dayText.color.g, _dayText.color.b, _dayText.color.a - 0.01f);
        yield return new WaitForSeconds(0.01f);
        if (_dayText.color.a > 0) StartCoroutine(Lighting());
        else
        {
            _dayText.gameObject.SetActive(false);
        }
    }
}
