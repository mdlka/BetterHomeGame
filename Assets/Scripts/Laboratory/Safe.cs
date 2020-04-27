using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Safe : MonoBehaviour
{
    [Header("Password")]
    [SerializeField] private string _password;

    [Header("Other")]
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _passwordPanel;
    [SerializeField] private InputField _input;

    private void Awake()
    {
        _passwordPanel.SetActive(false);
    }

    public void BeatOffBullet(ParticleSystem sparks)
    {
        Destroy(sparks.gameObject, sparks.main.startLifetimeMultiplier);
    }

    public void VerifyPassword()
    {
        if(_input.text.ToLower() == _password.ToLower())
        {
            Debug.Log("true");
            _winPanel.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if(player != null)
        {
            _passwordPanel.SetActive(true);
        }
    }
}
