using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAllGoldTimes : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        bool allGold = true;
        foreach(LevelCompletionData.LevelData l in LevelCompletionData.instance.levelData.levelData)
        {
            if(!l.haveGold)
            {
                allGold = false;
                break;
            }
        }
        if(allGold)
        {
            Destroy(gameObject);
        }
    }
}
