using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMostLevelsCompleted : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        bool allComplete = true;
        for(int i = 0; i < LevelCompletionData.instance.levels.Length - 1; ++i)
        {
            LevelCompletionData.LevelData l = LevelCompletionData.instance.levelData.levelData[i];
            if(!l.completed)
            {
                allComplete = false;
                break;
            }
        }
        if(allComplete)
        {
            Destroy(gameObject);
        }
    }
}
