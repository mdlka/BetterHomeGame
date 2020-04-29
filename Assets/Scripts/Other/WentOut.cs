using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WentOut : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] AudioSource _clickSound;

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    public void CloseWentOut()
    {
        _clickSound.Play();
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
