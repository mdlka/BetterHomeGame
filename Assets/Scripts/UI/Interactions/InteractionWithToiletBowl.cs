using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionWithToiletBowl : MonoBehaviour
{
    [SerializeField] private GameObject _toiletBowlButton;
    [SerializeField] private IndicatorsChange _indicatorsChange;
    [SerializeField] private PlayerController _playerContoller;
    [SerializeField] private ParticleSystem _urine;
    [SerializeField] [Range(0, 100)] private int _pauseTime;

    private bool _toiletBowlPause;

    private void Awake()
    {
        if (_toiletBowlButton.activeSelf) _toiletBowlButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_toiletBowlPause == false)
        {
            Player player = collision.GetComponent<Player>();

            if (player != null)
            {
                _toiletBowlButton.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _toiletBowlButton.SetActive(false);
    }

    public void ToiletBowlButton()
    {
        if(_playerContoller.GetFacingRight() == false && _playerContoller.GetSpeed() == 0)
        {
            StartCoroutine(Pissing());
        }
    }

    IEnumerator Pissing()
    {
        _urine.Play();
        _playerContoller.enabled = false;
        _toiletBowlButton.SetActive(false);

        yield return new WaitForSeconds(8f);

        _playerContoller.enabled = true;

        _indicatorsChange.SetHealthValue(0.1f);
        _indicatorsChange.SetHappyValue(0.1f);

        StartCoroutine(ToiletBowlPause());
    }

    IEnumerator ToiletBowlPause()
    {
        _toiletBowlButton.SetActive(false);
        _toiletBowlPause = true;

        yield return new WaitForSeconds(_pauseTime);

        _toiletBowlPause = false;
    }
}
