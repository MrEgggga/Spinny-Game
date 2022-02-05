using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void QuitGame()
    {
        LevelCompletionData.instance.SaveData();
        Application.Quit();
    }
}
