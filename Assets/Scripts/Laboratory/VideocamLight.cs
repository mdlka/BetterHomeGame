using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideocamLight : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] private float _addedSuspicion;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            player.SetSuspicionValue(player.Suspicion + _addedSuspicion);
        }
    }
}
