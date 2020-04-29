using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionWithBed : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private GameObject _bedButton;

    [Header("Sound")]
    [SerializeField] AudioSource _clickSound;

    [Header("Other")]
    [SerializeField] private Image _curtain;
    [SerializeField] private IndicatorsChange _indicatorsChange;

    private void Awake()
    {
        if (_bedButton.activeSelf) _bedButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            _bedButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _bedButton.SetActive(false);
    }

    public void Sleep()
    {
        _clickSound.Play();
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
