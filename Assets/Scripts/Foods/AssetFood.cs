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
    public int Price => _price;
    public string Description => _description;

    [SerializeField] private Sprite _uiIcon;
    [SerializeField] private string _name;
    [SerializeField] private float _health;
    [SerializeField] private float _energy;
    [SerializeField] private float _food;
    [SerializeField] private int _price;
    [SerializeField] [TextArea(5, 10)] private string _description;
}
