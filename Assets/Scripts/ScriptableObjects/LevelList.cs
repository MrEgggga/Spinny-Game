using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelList", order = 1)]
public class LevelList : ScriptableObject
{
    public Level[] levels;
    public Level[] secretLevels;
    public int winScene;
}
