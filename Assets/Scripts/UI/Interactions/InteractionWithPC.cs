using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionWithPC : MonoBehaviour
{
    [SerializeField] private GameObject _pcMenu;
    [SerializeField] private GameObject _shopMenu;
    [SerializeField] private Button _jobButton;

    [SerializeField] private Money _money;

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
        _pcMenu.SetActive(true);
        _shopMenu.SetActive(false);
    }

    public void ShopButton()
    {
        _pcMenu.SetActive(false);
        _shopMenu.SetActive(true);
    }

    public void JobButton()
    {
        _money.SetValue(_money.Value + 100);

        StartCoroutine(PauseJob());
    }

    IEnumerator PauseJob()
    {
        _jobButton.enabled = false;

        yield return new WaitForSeconds(5);

        _jobButton.enabled = true;
    }
}
