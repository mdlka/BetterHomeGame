using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaboratoryDoor : MonoBehaviour
{
    [Header("Load")]
    [SerializeField] LevelLoader _load;

    [Header("Save")]
    [SerializeField] private SaveAndLoadStreet _save;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if(player != null)
        {
            _save.SaveAll();
            _load.LoadLevel(3);
        }
    }
}
