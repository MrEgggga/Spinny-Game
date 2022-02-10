using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearData : MonoBehaviour
{
    public void Clear()
    {
        LevelCompletionData.instance.ClearData();
    }
}
