using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseCheckGold : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Check", 0f);
    }

    void Check()
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
        if(!allGold)
        {
            Destroy(gameObject);
        }
    }
}
