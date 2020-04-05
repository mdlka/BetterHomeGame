using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Food", order = 150)]
public class AssetFood : ScriptableObject, IFood
{
    public string Name => _name;
    public Sprite UIIcon => _uiIcon;

    [SerializeField] private string _name;
    [SerializeField] private float _health;
    [SerializeField] private float _energy;
    [SerializeField] private float _food;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _uiIcon;
}
