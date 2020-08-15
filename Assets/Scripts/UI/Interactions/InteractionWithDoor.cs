using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionWithDoor : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private GameObject _doorButton;
    [SerializeField] private GameObject _textTakeKnife;

    [Header("Knife")]
    [SerializeField] private InteractionWithKnife _knife;

    [Header("Sound")]
    [SerializeField] AudioSource _clickSound;

    [Header("Load")]
    [SerializeField] LevelLoader _load;

    [Header("Save")]
    [SerializeField] private SaveAndLoadHome _save;

    private void Awake()
    {
        if (_doorButton.activeSelf) _doorButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            if (_knife.GetKnifeInArm())
            {
                _doorButton.SetActive(true);
            }
            else
            {
                _textTakeKnife.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _doorButton.SetActive(false);
        _textTakeKnife.SetActive(false);
    }

    public void DoorButton()
    {
        _clickSound.Play();

        _save.SaveAll();
        _load.LoadLevel(2);
    }
}
