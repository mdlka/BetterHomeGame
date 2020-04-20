using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUIView : MonoBehaviour
{
    [SerializeField] private Gun _gun;
    [SerializeField] private Text _ammoValue;

    private void OnEnable()
    {
        _gun.AmmoChanged += OnAmmoChanged;

        OnAmmoChanged(_gun.AmmoValue);
    }

    private void OnDisable()
    {
        _gun.AmmoChanged -= OnAmmoChanged;
    }

    private void OnAmmoChanged(int value)
    {
        _ammoValue.text = value.ToString();
    }
}
