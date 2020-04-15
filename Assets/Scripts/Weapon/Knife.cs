using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        //if(enemy != null)
        //{

        //}
    }
}
