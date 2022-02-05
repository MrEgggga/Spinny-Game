using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawner : MonoBehaviour
{
    private LevelCompletionData lcd;
    public GameObject levelButton;
    public bool secretLevels;
    public RectTransform viewportContent;

    // Start is called before the first frame update
    void Start()
    {
        lcd = LevelCompletionData.instance;
        for(int i = 0; i < (secretLevels ? lcd.secretLevels.Length : lcd.levels.Length); ++i)
        {
            Instantiate(levelButton, viewportContent).GetComponent<LevelSelectButton>().level = i;
        }
    }
}
