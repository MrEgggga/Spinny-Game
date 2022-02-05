using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("SpeedrunTimerText").GetComponent<SpeedrunTimer>().StartTimer();
    }
}
