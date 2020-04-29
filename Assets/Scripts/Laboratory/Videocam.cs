using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Videocam : MonoBehaviour
{
    [SerializeField] private ParticleSystem _break;
    [SerializeField] private AudioSource _breakSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();

        if(bullet != null)
        {
            _breakSound.Play();

            Instantiate(_break, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
