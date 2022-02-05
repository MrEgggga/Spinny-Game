using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class NextLevelButton : MonoBehaviour
{
    private static LevelCompletionData lcd = LevelCompletionData.instance;

    public void NextLevel()
    {
        int levelNumber = lcd.levels.TakeWhile(l => !(l.buildIndex == SceneManager.GetActiveScene().buildIndex)).Count();
        if(levelNumber + 1 < lcd.levels.Length)
        {
            SceneManager.LoadScene(lcd.levels[levelNumber + 1].buildIndex);
        }
        else
        {
            SceneManager.LoadScene(lcd.winScene);
        }
    }
}
