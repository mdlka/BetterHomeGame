using System;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private Save _save = new Save();

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Save"))
        {
            _save = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("Save"));
        }
        else
        {
            SetGameExists(false);
            SetIndicators(1f, 1f, 1f, 1f, 500);
            SetPlayerPosition(new Vector3(-23.8f, -1.36f, 0f));
            SetIsKnifeInArm(false);
            SetDay(30);
            SetScene(1);
        }
    }

    public void SaveGame()
    {
        PlayerPrefs.SetString("Save", JsonUtility.ToJson(_save));
    }

    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
    }

    public void SetGameExists(bool gameExists)
    {
        _save.gameExists = gameExists;
    }

    public void SetIndicators(float health, float energy, float food, float happy, int money)
    {
        _save.health = health;
        _save.energy = energy;
        _save.food = food;
        _save.happy = happy;
        _save.money = money;
    }

    public void SetFoods(AssetFood[] foods)
    {
        _save.foods = foods;
    }

    public void SetPlayerPosition(Vector3 playerPosition)
    {
        _save.playerPosition = playerPosition;
    }

    public void SetIsKnifeInArm(bool isKnifeInArm)
    {
        _save.isKnifeInArm = isKnifeInArm;
    }

    public void SetScene(int scene)
    {
        _save.scene = scene;
    }

    public void SetDay(int day)
    {
        _save.day = day;
    }

    public void SetHaveGun(bool haveGun)
    {
        _save.haveGun = haveGun;
    }

    public void SetAmmoValue(int value)
    {
        _save.ammoValue = value;
    }

    public bool GetGameExists() { return _save.gameExists; }

    public float GetHealth() { return _save.health; }
    public float GetEnergy() { return _save.energy; }
    public float GetFood() { return _save.food; }
    public float GetHappy() { return _save.happy; }
    public int GetMoney() { return _save.money; }

    public AssetFood[] GetFoods() { return _save.foods; }
    public Vector3 GetPlayerPosition() { return _save.playerPosition; }
    public bool GetIsKnifeInArm() { return _save.isKnifeInArm; }

    public int GetScene() { return _save.scene; }

    public int GetDay() { return _save.day; }

    public bool GetHaveGun() { return _save.haveGun; }
    public int GetAmmoValue() { return _save.ammoValue; }
}

[Serializable]
public class Save
{
    public bool gameExists;

    public float health;
    public float energy;
    public float food;
    public float happy;
    public int money;

    public AssetFood[] foods;
    public bool isKnifeInArm;
    public int day;
    public Vector3 playerPosition;

    public bool haveGun;
    public int ammoValue;

    public int scene;
}
