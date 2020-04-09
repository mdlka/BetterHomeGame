using System;
using UnityEngine;
using UnityEngine.UI;

public class FridgeButton : MonoBehaviour
{
    [SerializeField] private GameObject _fridgeMenu;
    [SerializeField] private Fridge _fridge;
    [SerializeField] private Text _text;

    public void InteractionWithFridge()
    {
        if(_fridgeMenu.activeSelf == false)
        {
            _fridgeMenu.SetActive(true);
            _text.text = "Закрыть";
        }
        else
        {
            _fridgeMenu.SetActive(false);
            _text.text = "Открыть";
        }
    }
}
