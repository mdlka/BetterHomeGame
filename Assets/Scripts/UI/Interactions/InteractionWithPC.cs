using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionWithPC : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] private GameObject _pcMenu;
    [SerializeField] private GameObject _shopMenu;

    [Header("Button")]
    [SerializeField] private Button _jobButton;

    [Header("Money")]
    [SerializeField] private Money _money;

    [Header("Sound")]
    [SerializeField] AudioSource _PCSound;
    [SerializeField] AudioClip _jobSound;
    [SerializeField] AudioClip _clickSound;

    private void Awake()
    {
        if (_pcMenu.activeSelf) _pcMenu.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            _pcMenu.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _pcMenu.SetActive(false);
        _shopMenu.SetActive(false);
    }

    public void CloseButton()
    {
        _PCSound.PlayOneShot(_clickSound);

        _pcMenu.SetActive(true);
        _shopMenu.SetActive(false);
    }

    public void ShopButton()
    {
        _PCSound.PlayOneShot(_clickSound);

        _pcMenu.SetActive(false);
        _shopMenu.SetActive(true);
    }

    public void JobButton()
    {
        _PCSound.PlayOneShot(_jobSound);

        _money.SetValue(_money.Value + 100);
        StartCoroutine(PauseJob());
    }

    IEnumerator PauseJob()
    {
        _jobButton.interactable = false;

        yield return new WaitForSeconds(5);

        _jobButton.interactable = true;
    }
}
