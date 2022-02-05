using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecialModeButton : MonoBehaviour
{
    public void ToggleSpecial()
    {
        LevelCompletionData.instance.ToggleSpecialMode();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
