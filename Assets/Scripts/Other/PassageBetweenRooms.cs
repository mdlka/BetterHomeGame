using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageBetweenRooms : MonoBehaviour
{
    [SerializeField] private CameraMovement _camera;
    [SerializeField] private float _centerRoomX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if(player != null)
        {
            _camera.Move(_centerRoomX);
        }
    }
}
