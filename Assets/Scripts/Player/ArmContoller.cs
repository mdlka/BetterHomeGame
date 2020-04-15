using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmContoller : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _offset;

    private void FixedUpdate()
    { 
        ArmControl();
    }

    private void ArmControl()
    {
        Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + _offset);

        if (_playerController.GetFacingRight()) transform.Rotate(0f, 0f, 0f);
        else transform.Rotate(0f, 180f, 0f);
    }
}
