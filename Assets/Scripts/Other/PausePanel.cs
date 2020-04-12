using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private Pause _pause;

    private void OnEnable()
    {
        _pause.PauseGame();
    }

    private void OnDisable()
    {
        _pause.BackToGame();
    }
}
