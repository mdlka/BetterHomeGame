using UnityEngine;
using UnityEngine.UI;

public class InteractionWithFridge : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] private GameObject _fridgeMenu;

    [Header("Button")]
    [SerializeField] private GameObject _fridgeButton;
    [SerializeField] private Text _text;

    [Header("Sound")]
    [SerializeField] AudioSource _clickSound;

    private void Awake()
    {
        if (_fridgeButton.activeSelf) _fridgeButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            _fridgeButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CloseOrOpenMenu("Открыть", false);
    }

    public void FridgeButton()
    {
        _clickSound.Play();

        if (_fridgeMenu.activeSelf == false)
        {
            CloseOrOpenMenu("Закрыть", true);
        }
        else
        {
            CloseOrOpenMenu("Открыть", false);
        }
    }

    private void CloseOrOpenMenu(string text, bool menuActive)
    {
        _fridgeButton.SetActive(menuActive);
        _text.text = text;
        _fridgeMenu.SetActive(menuActive);
    }
}
