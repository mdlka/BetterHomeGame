using System;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private Indicator _health;
    [SerializeField] private Indicator _energy;
    [SerializeField] private Indicator _food;
    [SerializeField] private Indicator _happy;
    [SerializeField] private Money _money;

    [SerializeField] private Transform _playerPosition;
    [SerializeField] private Fridge _fridge;

    private Save _save = new Save();
    private string _path;

    private void Awake()
    {
        _path = Path.Combine(Application.dataPath, "Save.json");

        if (File.Exists(_path))
        {
            _save = JsonUtility.FromJson<Save>(File.ReadAllText(_path));
        }
        else
        {
            SetIndicators(1f, 1f, 1f, 1f, 500);
            SetPlayerPosition(new Vector3(-23.8f, -1.36f, 0f));
        }
    }

    private void OnApplicationQuit()
    {
        SetIndicators(_health.Value, _energy.Value, _food.Value, _happy.Value, _money.Value);
        SetPlayerPosition(_playerPosition.position);
        SetFoods(_fridge.GetFoods());

        File.WriteAllText(_path, JsonUtility.ToJson(_save));
    }

    public void SetIndicators(float health, float energy, float food, float happy, int money)
    {
        _save.health = health;
        _save.energy = energy;
        _save.food = food;
        _save.happy = happy;
        _save.money = money;
    }

    public void SetPlayerPosition(Vector3 playerPosition)
    {
        _save.playerPosition = playerPosition;
    }

    public void SetFoods(AssetFood[] foods)
    {
        _save.foods = foods;
    }

    public float GetHealth() { return _save.health; }
    public float GetEnergy() { return _save.energy; }
    public float GetFood() { return _save.food; }
    public float GetHappy() { return _save.happy; }
    public int GetMoney() { return _save.money; }

    public Vector3 GetPlayerPosition() { return _save.playerPosition; }

    public AssetFood[] GetFoods() { return _save.foods; }
}

[Serializable]
public class Save
{
    public float health;
    public float energy;
    public float food;
    public float happy;
    public int money;

    public AssetFood[] foods;

    public Vector3 playerPosition;
}
