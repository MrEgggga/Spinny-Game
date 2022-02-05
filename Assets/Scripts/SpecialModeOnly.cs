using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialModeOnly : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(!LevelCompletionData.instance.specialMode)
        {
            Destroy(gameObject);
        }   
    }
}
