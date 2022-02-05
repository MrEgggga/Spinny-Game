using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("SpeedrunTimer") != null) Destroy(GameObject.Find("SpeedrunTimer"));
    }
}
