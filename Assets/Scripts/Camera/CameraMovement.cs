using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] [Range(0, 100)] private float _smoothTime;

    [SerializeField] private float[] _betweenRoomsX;
    [SerializeField] private float[] _centersRoomsX;

    private Vector3 _target;
    private float _baseY;
    private float _baseZ;

    private Vector3 _currentVelocity;

    private void Awake()
    {
        _baseY = transform.position.y;
        _baseZ = transform.position.z;
    }

    private void FixedUpdate()
    {
        Move(_player.position);
    }

    private void Move(Vector3 target)
    {
        if (target.x < _betweenRoomsX[0])
            _target = new Vector3(_centersRoomsX[0], _baseY, _baseZ);
        else if (target.x > _betweenRoomsX[0] && target.x < _betweenRoomsX[1])
            _target = new Vector3(_centersRoomsX[1], _baseY, _baseZ);
        else if (target.x > _betweenRoomsX[1] && target.x < _betweenRoomsX[2])
            _target = new Vector3(_centersRoomsX[2], _baseY, _baseZ);
        else if (target.x > _betweenRoomsX[2])
            _target = new Vector3(_centersRoomsX[3], _baseY, _baseZ);

        transform.position = Vector3.SmoothDamp(transform.position, _target, ref _currentVelocity, _smoothTime * Time.fixedDeltaTime);
    }
}
