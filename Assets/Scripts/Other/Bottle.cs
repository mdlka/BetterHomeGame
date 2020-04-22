using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    [SerializeField] private int _healthAdd;
    [SerializeField] private ParticleSystem _break;
    [SerializeField] private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();

        if(bullet != null)
        {
            _player.SetHealthValue(_player.Health + _healthAdd);

            Instantiate(_break, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
