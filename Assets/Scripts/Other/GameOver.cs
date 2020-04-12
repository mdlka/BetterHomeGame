using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private IndicatorsChange _indicatorsChange;
    [SerializeField] private Money _money;

    public void NewGameButton()
    {
        _indicatorsChange.SetHealthValue(1);
        _indicatorsChange.SetEnergyValue(1);
        _indicatorsChange.SetFoodValue(1);
        _indicatorsChange.SetHappyValue(1);

        _money.SetValue(1000);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
