using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger3D : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject == player && player.GetComponent<Player3D>().main)
        {
            player.GetComponent<Player3D>().Win();
        }
    }
}
