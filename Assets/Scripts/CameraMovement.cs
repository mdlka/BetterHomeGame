using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 _target;
    private float _baseY;
    private float _baseZ;

    private void Awake()
    {
        _baseY = transform.position.y;
        _baseZ = transform.position.z;
    }

    public void Move(float targetX)
    {
        _target = new Vector3(targetX, _baseY, _baseZ);
        transform.position = _target;
    }
}
