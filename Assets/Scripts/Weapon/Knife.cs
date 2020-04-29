using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField] private int _damage;

    [Header("Sound")]
    [SerializeField] AudioSource _beatOffBulletSound;

    [Header("Other")]
    [SerializeField] private ParticleSystem _blood;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if(enemy != null)
        {
            ParticleSystem blood = Instantiate(_blood, transform.position, _blood.transform.rotation);
            enemy.TakeDamage(_damage, blood, false);
        }
    }

    public void BeatOffBullet(ParticleSystem sparks)
    {
        _beatOffBulletSound.pitch = Random.Range(0.9f, 1.1f);
        _beatOffBulletSound.Play();
        Destroy(sparks.gameObject, sparks.main.startLifetimeMultiplier);
    }
}
