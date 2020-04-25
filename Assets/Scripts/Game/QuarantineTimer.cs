using System.Collections;
using System;
using UnityEngine;

public class QuarantineTimer : MonoBehaviour
{
    [SerializeField] private int _day;
    [SerializeField] private float _timeForDay;

    public event Action<int> Changed;

    public int Day => _day;

    IEnumerator DayTimer()
    {
        yield return new WaitForSeconds(_timeForDay);

        _day -= 1;
        UpdateDayValue();

        StartCoroutine(DayTimer());
    }

    private void UpdateDayValue()
    {
        Changed?.Invoke(_day);
    }

    public void SetDay(int day)
    {
        _day = day;
        UpdateDayValue();

        StartCoroutine(DayTimer());
    }
}
