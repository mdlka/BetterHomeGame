using System.Collections;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<int> HealthChanged;

    public int Health => _health;

    [Header("Settings Player")]
    [SerializeField] private int _health;

    [Header("Weapon")]
    [SerializeField] private Gun _gun;
    [SerializeField] private Knife _knife;

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

    }

    public void TakeDamage(int damage, ParticleSystem blood)
    {
        Destroy(blood.gameObject, blood.main.startLifetimeMultiplier);
        _health -= damage;

        UpdateHealthValue();

        if (_health <= 0)
        {
            
        }
    }

    private void TakeDrop(AmmoDrop drop)
    {
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
}
