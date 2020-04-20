using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionWithKnife : MonoBehaviour
{
    [SerializeField] private GameObject _knifeButton;
    [SerializeField] private GameObject _knifeInArm;

    private bool _isKnifeInArm;

    private void Awake()
    {
        if (_knifeButton.activeSelf) _knifeButton.SetActive(false);

        if (_isKnifeInArm == true) gameObject.SetActive(false);
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
        _isKnifeInArm = true;
        _knifeInArm.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SetKnifeInArm(bool isKnifeInArm)
    {
        if(isKnifeInArm == true)
        {
            _knifeInArm.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public bool GetKnifeInArm()
    {
        return _isKnifeInArm;
    }
}
