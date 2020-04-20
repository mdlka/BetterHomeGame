using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _blood;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if(enemy != null)
        {
            ParticleSystem blood = Instantiate(_blood, transform.position, _blood.transform.rotation);
            enemy.TakeDamage(_damage, blood);
        }
    }

    public void BeatOffBullet(ParticleSystem sparks)
    {
        Destroy(sparks.gameObject, sparks.main.startLifetimeMultiplier);
    }
}
