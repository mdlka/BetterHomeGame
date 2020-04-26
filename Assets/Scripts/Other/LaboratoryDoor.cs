using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaboratoryDoor : MonoBehaviour
{
    [SerializeField] private SaveAndLoadStreet _save;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if(player != null)
        {
            _save.SaveAll();
            SceneManager.LoadScene(3);
        }
    }
}
