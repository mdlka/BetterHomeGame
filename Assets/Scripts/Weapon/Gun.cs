using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Setting Gun")]
    [SerializeField] private int _damage;
    [SerializeField] private int _amountAmmo;
    [SerializeField] private float _timeBetweenShots;
    [SerializeField] private float _timeReload;

    [Header("Other")]
    [SerializeField] private BulletObjectPool _bulletObjectPool;
    [SerializeField] private Transform _shotDirection;

    [SerializeField] private ParticleSystem _shot;

    private int _defaultAmountAmmo;
    private bool _isReload;

    private void Awake()
    {
        _defaultAmountAmmo = _amountAmmo;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isReload == false)
            {
                Shot();
            }
        }
    }

    private void Shot()
    {
        _shot.Play();
        SpawnBullet();

        _amountAmmo--;
        if(_amountAmmo <= 0)
        {
            StartCoroutine(Reload(_timeReload, _defaultAmountAmmo));
        }
        else
        {
            StartCoroutine(Reload(_timeBetweenShots));
        }
    }

    IEnumerator Reload(float time, int amountAmmo = 0)
    {
        _isReload = true;

        yield return new WaitForSeconds(time);

        _amountAmmo += amountAmmo;
        _isReload = false;
    }

    private void SpawnBullet()
    {
        Bullet bullet = null;

        bullet = _bulletObjectPool.Get();
        bullet.transform.position = _shotDirection.position;
        bullet.transform.rotation = transform.rotation;
        bullet.SetDamage(_damage);

        bullet.gameObject.SetActive(true);
    }  
}
