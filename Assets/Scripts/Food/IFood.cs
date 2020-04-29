using UnityEngine;

public interface IFood
{
    Sprite UIIcon { get; }
    string Name { get; }
    float Health { get; }
    float Energy { get; }
    float Food { get; }
    float Happy { get; }
    int Price { get; }
    bool isWater { get; }
}
