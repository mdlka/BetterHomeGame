using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] private float _speed;
    [SerializeField] private Animator _animator;

    [SerializeField] private bool _inHome = true;

    private float _horizontalMove;
    private bool _facingRight = true;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        if (_inHome == false) Flip();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _horizontalMove = Input.GetAxis("Horizontal");

        _animator.SetFloat("Speed", Mathf.Abs(_horizontalMove));

        if (_horizontalMove > 0 && _facingRight == false)
        {
            Flip();
        }
        else if (_horizontalMove < 0 && _facingRight)
        {
            Flip();
        }

        _rb.velocity = new Vector2(_horizontalMove * _speed, _rb.velocity.y);
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public bool GetFacingRight()
    {
        return _facingRight;
    }

    public float GetSpeed()
    {
        return _horizontalMove;
    }
}
