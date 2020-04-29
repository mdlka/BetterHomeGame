using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Safe : MonoBehaviour
{
    [Header("Password")]
    [SerializeField] private string _password;

    [Header("Sound")]
    [SerializeField] AudioSource _safeSound;
    [SerializeField] AudioClip _click;
    [SerializeField] AudioClip _beatOffBullet;

    [Header("Other")]
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private InputField _input;

    public void BeatOffBullet(ParticleSystem sparks)
    {
        _safeSound.pitch = Random.Range(0.9f, 1.1f);
        _safeSound.PlayOneShot(_beatOffBullet);
        Destroy(sparks.gameObject, sparks.main.startLifetimeMultiplier);
    }

    public void VerifyPassword()
    {
        _safeSound.PlayOneShot(_click);

        if (_input.text.ToLower() == _password.ToLower())
        {
            _winPanel.SetActive(true);
        }
    }
}
