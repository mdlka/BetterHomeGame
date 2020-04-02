using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _leftBorderX;
    [SerializeField] private float _rightBorderX;

    [SerializeField] [Range(0, 100)] private float _smoothTime;
    [SerializeField] private float _offsetX;
    [SerializeField] private Transform _player;


    private Vector3 _target;
    private float _baseY;
    private float _baseZ;

    private Vector3 _currentVelocity;

    private bool _isRight;
    private int _lastX;

    private void Awake()
    {
        _baseY = transform.position.y;
        _baseZ = transform.position.z;
    }

    private void FixedUpdate()
    {
        Follow(_player.position);
    }

    private void Follow(Vector3 target)
    {
        FlipOffset(target);

        _target = new Vector3(target.x + _offsetX, _baseY, _baseZ);
        _target.x = Mathf.Clamp(_target.x, _leftBorderX, _rightBorderX);

        transform.position = Vector3.SmoothDamp(transform.position, _target, ref _currentVelocity, _smoothTime * Time.fixedDeltaTime);
    }

    private void FlipOffset(Vector3 target)
    {
        int currentX = Mathf.RoundToInt(target.x);

        if (_lastX > currentX && _isRight == false)
        {
            _isRight = true;
            _offsetX *= -1;
        }
        else if (_lastX < currentX && _isRight)
        {
            _isRight = false;
            _offsetX *= -1;
        }

        _lastX = Mathf.RoundToInt(target.x);
    }
}
