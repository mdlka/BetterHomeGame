﻿using System.Collections;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<int> HealthChanged;
    public event Action<float> SuspicionChanged;

    public int Health => _health;
    public float Suspicion { get; private set; }

    [Header("Settings Player")]
    [SerializeField] private int _health;

    [Header("Weapon")]
    [SerializeField] private Gun _gun;
    [SerializeField] private Knife _knife;

    [Header("Sound")]
    [SerializeField] AudioSource _sound;
    [SerializeField] AudioClip _bulletInBody;
    [SerializeField] AudioClip _takeAmmo;

    [Header("Other")]
    [SerializeField] private bool _inHome;

    private bool _haveGun;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _inHome == false)
        {
            if (_gun.gameObject.activeSelf)
            {
                _gun.Shot();
            }
        }
        else if (Input.GetMouseButtonDown(1) && _inHome == false)
        {
            if (_haveGun)
            {
                if (_gun.gameObject.activeSelf)
                {
                    _gun.gameObject.SetActive(false);
                    _knife.gameObject.SetActive(true);
                }
                else if(_gun.gameObject.activeSelf == false)
                {
                    _gun.gameObject.SetActive(true);
                    _knife.gameObject.SetActive(false);
                }
            }
        }

        if (Suspicion > 0 && Time.timeScale != 0) SetSuspicionValue(Suspicion - 0.05f);
    }

    public void TakeDamage(int damage, ParticleSystem blood)
    {
        _sound.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
        _sound.PlayOneShot(_bulletInBody);

        Destroy(blood.gameObject, blood.main.startLifetimeMultiplier);
        _health -= damage;

        UpdateHealthValue();

        if (_health <= 0)
        {
            
        }
    }

    private void TakeDrop(AmmoDrop drop)
    {
        _sound.pitch = 1f;
        _sound.PlayOneShot(_takeAmmo);

        if (_haveGun == false)
        {
            _haveGun = true;
            _knife.gameObject.SetActive(false);
            _gun.gameObject.SetActive(true);
        }

        _gun.SetAmmoValue(_gun.AmmoValue + drop.Ammo);
        Destroy(drop.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AmmoDrop drop = collision.GetComponent<AmmoDrop>();

        if (drop != null)
        {
            TakeDrop(drop);
        }
    }

    private void UpdateHealthValue()
    {
        HealthChanged?.Invoke(_health);
    }

    public void SetHealthValue(int value)
    {
        _health = value;
        _health = Mathf.Clamp(_health, 0, 100);
        UpdateHealthValue();
    }

    private void UpdateSuspicionValue()
    {
        SuspicionChanged?.Invoke(Suspicion);
    }

    public void SetSuspicionValue(float value)
    {
        Suspicion = value;
        Suspicion = Mathf.Clamp(Suspicion, 0, 100);
        UpdateSuspicionValue();
    }

    public void SetHaveGun(bool haveGun)
    {
        _haveGun = haveGun;
    }

    public bool GetHaveGun()
    {
        return _haveGun;
    }
}
