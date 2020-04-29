using System;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public event Action Hitting;

    [SerializeField] private float _speed;
    [SerializeField] private ParticleSystem _blood;
    [SerializeField] private ParticleSystem _sparks;

    private int _damage;

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        Player player = collision.gameObject.GetComponent<Player>();
        Knife knife = collision.gameObject.GetComponent<Knife>();
        Safe safe = collision.gameObject.GetComponent<Safe>();   

        if (enemy != null)
        {
            ParticleSystem blood = Instantiate(_blood, transform.position, _blood.transform.rotation);
            enemy.TakeDamage(_damage, blood, true);      
        }
        else if(player != null)
        {
            ParticleSystem blood = Instantiate(_blood, transform.position, _blood.transform.rotation);
            player.TakeDamage(_damage, blood);
        }
        else if(knife != null)
        {
            ParticleSystem sparks = Instantiate(_sparks, transform.position, _sparks.transform.rotation);
            knife.BeatOffBullet(sparks);
        }
        else if(safe != null)
        {
            ParticleSystem sparks = Instantiate(_sparks, transform.position, _sparks.transform.rotation);
            safe.BeatOffBullet(sparks);
        }

        Hitting?.Invoke();
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }
}
