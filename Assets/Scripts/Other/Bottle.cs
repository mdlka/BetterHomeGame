using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    [Header("Added Health")]
    [SerializeField] private int _healthAdd;

    [Header("Sound")]
    [SerializeField] private AudioSource _breakBottleSourse;

    [Header("Other")]
    [SerializeField] private ParticleSystem _break;
    [SerializeField] private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();

        if(bullet != null)
        {
            _player.SetHealthValue(_player.Health + _healthAdd);

            _breakBottleSourse.Play();
            Instantiate(_break, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
