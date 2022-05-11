using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAllCollectibles : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        bool allCollected = true;
        for(int i = 0; i < 20; ++i)
        {
            bool c = LevelCompletionData.instance.levelData.secrets[i];
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
