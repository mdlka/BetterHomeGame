using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;

    private List<Bullet> _available = new List<Bullet>();
    private List<Bullet> _inUse = new List<Bullet>();

    private void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            Bullet bullet = null;

            bullet = Instantiate(_bullet);
            bullet.Hitting += () => Release(bullet);
            bullet.gameObject.SetActive(false);
            _available.Add(bullet);
        }
    }

    public Bullet Get()
    {
        Bullet bullet = null;

        if(_available.Count == 0)
        {
            bullet = Instantiate(_bullet);
            bullet.Hitting += () => Release(bullet);
        }
        else
        {
            bullet = _available[0];
            _available.Remove(bullet);
        }

        _inUse.Add(bullet);
        return bullet;
    }

    public void Release(Bullet bullet)
    {
        if (_inUse.Remove(bullet) == false)
            return;

        bullet.gameObject.SetActive(false);
        _available.Add(bullet);
    }
}
