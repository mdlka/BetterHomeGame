using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bed : MonoBehaviour
{
    [SerializeField] private Image _curtain;
    [SerializeField] private IndicatorsChange _indicatorsChange;

    public void Sleep()
    {
        StartCoroutine(ImitationOfSleep());
    }

    IEnumerator ImitationOfSleep()
    {
        _curtain.gameObject.SetActive(true);
        StartCoroutine(Blackout());

        yield return new WaitForSeconds(3f);

        _indicatorsChange.SetHealthValue(0.1f);
        _indicatorsChange.SetEnergyValue(0.3f);
        _indicatorsChange.SetFoodValue(-0.5f);

        StartCoroutine(Lighting());
    }

    IEnumerator Blackout()
    {
        _curtain.color = new Color(_curtain.color.r, _curtain.color.g, _curtain.color.b, _curtain.color.a + 0.01f);
        yield return new WaitForSeconds(0.01f);
        if (_curtain.color.a < 1) StartCoroutine(Blackout());
    }

    IEnumerator Lighting()
    {
        _curtain.color = new Color(_curtain.color.r, _curtain.color.g, _curtain.color.b, _curtain.color.a - 0.01f);
        yield return new WaitForSeconds(0.01f);
        if (_curtain.color.a > 0) StartCoroutine(Lighting());
        else
        {
            _curtain.gameObject.SetActive(false); 
        }
    }
}
