using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionWithDoor : MonoBehaviour
{
    [SerializeField] private GameObject _doorButton;

    private void Awake()
    {
        if (_doorButton.activeSelf) _doorButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            _doorButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _doorButton.SetActive(false);
    }

    public void DoorButton()
    {
        SceneManager.LoadScene(1);
    }
}
