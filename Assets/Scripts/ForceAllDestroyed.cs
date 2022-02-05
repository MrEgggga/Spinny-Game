using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceAllDestroyed : MonoBehaviour
{
    public Player3D player;
    public GameObject[] objectsToDestroy;

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject g in objectsToDestroy)
        {
            if(g.activeSelf)
            {
                return;
            }
        }

        player.Win();
    }
}
