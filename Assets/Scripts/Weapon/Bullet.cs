using System;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public event Action Hitting;

    [SerializeField] private float _speed;
    [SerializeField] private ParticleSystem _blood;

    private int _damage;

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            ParticleSystem blood = Instantiate(_blood, transform.position, _blood.transform.rotation);
            enemy.TakeDamage(_damage, blood);      
        }

        Hitting?.Invoke();
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }
}
