using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectibleBoxes : MonoBehaviour
{
    public GameObject menuBox;

    // Start is called before the first frame update
    void Start()
    {
        LevelCompletionData lcd = LevelCompletionData.instance;
        foreach(bool c in lcd.levelData.secrets)
        {
            if(c) Instantiate(menuBox, transform.position, transform.rotation);
        }
    }
}
