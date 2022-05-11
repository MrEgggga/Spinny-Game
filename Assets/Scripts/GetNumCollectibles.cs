using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetNumCollectibles : MonoBehaviour
{
    private LevelCompletionData lcd;
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        lcd = LevelCompletionData.instance;
    }

    // Update is called once per frame
    void Update()
    {
        int collectibles = 0;
        foreach(bool c in lcd.levelData.secrets)
        {
            collectibles += c ? 1 : 0;
        }
        if(collectibles >= 20)
        {
            text.text = string.Format("{0}/21", collectibles);
            return;
        }
        text.text = string.Format("{0}/20", collectibles);
    }
}
