using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("SpeedrunTimerText") != null) GameObject.Find("SpeedrunTimerText").GetComponent<SpeedrunTimer>().StopTimer();
    }
}
