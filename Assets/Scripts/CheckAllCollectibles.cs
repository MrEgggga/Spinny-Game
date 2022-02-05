using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAllCollectibles : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        bool allCollected = true;
        foreach(bool c in LevelCompletionData.instance.levelData.secrets)
        {
            if(!c)
            {
                allCollected = false;
                break;
            }
        }
        if(!allCollected)
        {
            Destroy(gameObject);
        }
    }
}
