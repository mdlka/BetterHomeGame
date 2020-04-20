using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Settings Enemy")]
    [SerializeField] [Range(50, 500)] private int _health;

    [Header("Settings Gun")]
    [SerializeField] private Gun _gun;
    [SerializeField] private int _offsetZ;

    [Header("Other")]
    [SerializeField] private Drop _drop;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _arm;


    private Animator _anim;
    private bool _isAlive = true;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (_isAlive)
        {
            ArmControl();
        }
    }

    private void ArmControl()
    {
        Vector3 targetDirection = _target.position - _arm.position;
        float angleDirection = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        _arm.rotation = Quaternion.Euler(0f, 180f, angleDirection + _offsetZ);

        if(Mathf.Abs(targetDirection.x) < 20)
        {
            _gun.Shot();
        }
    }

    public void TakeDamage(int damage, ParticleSystem blood)
    {
        Destroy(blood.gameObject, blood.main.startLifetimeMultiplier);
        _health -= damage;

        if (_health <= 0 && _isAlive)
        {
            Death();
        }
    }

    private void Death()
    {
        _isAlive = false;
        _drop.Droped();
        _anim.enabled = false;

        transform.Rotate(0, 0, 90);
        transform.position = new Vector2(transform.position.x, transform.position.y - 1.386937f);

        _arm.rotation = Quaternion.Euler(0f, 180f, -90f + Random.Range(0f, 180f));

        StartCoroutine(DestroyAfterDeath());
    }

    IEnumerator DestroyAfterDeath()
    {
        yield return new WaitForSeconds(10);

        Destroy(gameObject);
    }
}
