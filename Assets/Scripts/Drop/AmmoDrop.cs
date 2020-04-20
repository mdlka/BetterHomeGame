using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDrop : MonoBehaviour
{
    private int _ammo;

    public int Ammo => _ammo;

    private void Awake()
    {
        _ammo = Random.Range(1, 5);
    }
}
