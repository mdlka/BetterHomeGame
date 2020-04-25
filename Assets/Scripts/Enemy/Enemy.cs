using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Settings Enemy")]
    [SerializeField] [Range(50, 500)] private int _health;

    [Header("Settings Gun")]
    [SerializeField] private Gun _gun;
    [SerializeField] private float _distanceToTarget;

    [Header("Setting Arm")]
    [SerializeField] private int _offsetZ;
    [SerializeField] private int _offsetY;

    [Header("Other")]
    [SerializeField] private Drop _drop;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _arm;

    private Animator _anim;
    private bool _isLeft = false;
    private bool _isAlive = true;

    private void Awake()
    {
        _anim = GetComponent<Animator>();

        if (_isLeft == false) Flip();
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
        Vector3 targetDistance = _target.position - _arm.position;
        float angleDirection = Mathf.Atan2(targetDistance.y, Mathf.Abs(targetDistance.x)) * Mathf.Rad2Deg;
        _arm.rotation = Quaternion.Euler(0f, _offsetY, angleDirection + _offsetZ);

        if (targetDistance.x < 0.1f && _isLeft == false || targetDistance.x > 0.1f && _isLeft) Flip();

        if(Mathf.Abs(targetDistance.x) < _distanceToTarget)
        {
            _gun.Shot();
        }
    }

    private void Flip()
    {
        _isLeft = !_isLeft;

        _offsetY += 180;
        transform.Rotate(0f, 180f, 0f);
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
