using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionWithKnife : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private GameObject _knifeButton;
    [SerializeField] private Text _buttonText;

    [Header("Knife")]
    [SerializeField] private GameObject _knifeInArm;

    [Header("Sound")]
    [SerializeField] AudioSource _clickSound;

    private SpriteRenderer _knife;
    private bool _isKnifeInArm;

    private void Start()
    {
        _knife = GetComponent<SpriteRenderer>();

        if (_knifeButton.activeSelf) _knifeButton.SetActive(false);

        if (_isKnifeInArm == true) _knife.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            _knifeButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _knifeButton.SetActive(false);
    }

    public void KnifeButton()
    {
        _clickSound.Play();

        if (_isKnifeInArm == false)
        {
            _isKnifeInArm = true;
            _knifeInArm.SetActive(true);
            _knife.enabled = false;

            _buttonText.text = "Положить";
        }
        else
        {
            _isKnifeInArm = false;
            _knifeInArm.SetActive(false);
            _knife.enabled = true;

            _buttonText.text = "Взять";
        }

        _knifeButton.SetActive(false);
    }

    public void SetKnifeInArm(bool isKnifeInArm)
    {
        if(isKnifeInArm == true)
        {
            _isKnifeInArm = true;
            _knifeInArm.SetActive(true);
            _knife.enabled = false;

            _buttonText.text = "Положить";
        }
        else
        {
            _isKnifeInArm = false;
            _knifeInArm.SetActive(false);
            _knife.enabled = true;

            _buttonText.text = "Взять";
        }
    }

    public bool GetKnifeInArm()
    {
        return _isKnifeInArm;
    }
}
