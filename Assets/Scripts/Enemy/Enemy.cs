using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] [Range(50, 500)] private int _health;

    private void Awake()
    {
        
    }

    public void TakeDamage(int damage, ParticleSystem blood)
    {
        Destroy(blood.gameObject, blood.main.startLifetimeMultiplier);
        _health -= damage;

        if (_health <= 0) Destroy(gameObject);
    }
}
