using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionWithPerson : MonoBehaviour
{
    [SerializeField] GameObject _itemMenu;

    private void Awake()
    {
        if(_itemMenu.activeSelf) _itemMenu.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            _itemMenu.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _itemMenu.SetActive(false);
    }
}
