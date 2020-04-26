using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WentOut : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    public void CloseWentOut()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
