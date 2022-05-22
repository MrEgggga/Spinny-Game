using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StopTimer : MonoBehaviour
{
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("SpeedrunTimerText") != null)
        {
            text.text = string.Format("Game complete in {0:N3}", SpeedrunTimer.instance.elapsed);
        }
    }
}
