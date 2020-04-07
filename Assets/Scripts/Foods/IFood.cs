using UnityEngine;

public interface IFood
{
    Sprite UIIcon { get; }
    string Name { get; }
    float Health { get; }
    float Energy { get; }
    float Food { get; }
    int Price { get; }
    string Description { get; }
}
