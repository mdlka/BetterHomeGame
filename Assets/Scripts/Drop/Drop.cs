using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private GameObject _drop;

    public void Droped()
    {
        GameObject drop = null;
        drop = Instantiate(_drop, transform.position, transform.rotation);
    }
}
