using System.Collections;
using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public event Action<int> AmmoChanged;

    public int AmmoValue => _valueAmmo;

    [Header("Setting Gun")]
    [SerializeField] private int _damage;
    [SerializeField] private int _valueAmmo;
    [SerializeField] private float _timeReload;

    [Header("Sound")]
    [SerializeField] private AudioSource _gunSound;
    [SerializeField] private AudioClip _shotSound;
    [SerializeField] private AudioClip _noBulletsSound;

    [Header("Other")]
    [SerializeField] private BulletObjectPool _bulletObjectPool;
    [SerializeField] private Transform _shotDirection;
    [SerializeField] private ParticleSystem _shot;

    private bool _isReload;

    private void OnEnable()
    {
        if (_isReload) StartCoroutine(Reload(_timeReload));
    }

    public void Shot()
    { 
        if(Time.timeScale != 0)
        {
            if (_isReload == false && _valueAmmo > 0)
            {
                _gunSound.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
                _gunSound.PlayOneShot(_shotSound);

                _shot.Play();
                SpawnBullet();

                _valueAmmo--;
                StartCoroutine(Reload(_timeReload));
            }
            else if (_valueAmmo <= 0)
            {
                _gunSound.pitch = 1f;
                _gunSound.PlayOneShot(_noBulletsSound);
            }
        }
    }

    IEnumerator Reload(float time)
    {
        _isReload = true;

        yield return new WaitForSeconds(time);

        UpdateAmmoValue();
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

    private void UpdateAmmoValue()
    {
        AmmoChanged?.Invoke(_valueAmmo);
    }

    public void SetAmmoValue(int value)
    {
        _valueAmmo = value;
        UpdateAmmoValue();
    }
}
