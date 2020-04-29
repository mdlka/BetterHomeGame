using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Food", order = 150)]
public class AssetFood : ScriptableObject, IFood
{
    public Sprite UIIcon => _uiIcon;
    public string Name => _name;
    public float Health => _health;
    public float Energy => _energy;
    public float Food => _food;
    public float Happy => _happy;
    public int Price => _price;
    public bool isWater => _isWater;

    [SerializeField] private Sprite _uiIcon;
    [SerializeField] private string _name;
    [SerializeField] private float _health;
    [SerializeField] private float _energy;
    [SerializeField] private float _food;
    [SerializeField] private float _happy;
    [SerializeField] private int _price;
    [SerializeField] private bool _isWater;
}
