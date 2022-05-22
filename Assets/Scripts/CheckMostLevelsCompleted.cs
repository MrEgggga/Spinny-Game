using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMostLevelsCompleted : MonoBehaviour
{
    public int levels = 20;

    // Update is called once per frame
    void Update()
    {
        bool allComplete = true;
        for(int i = 0; i < levels; ++i)
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
