using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible3D : MonoBehaviour
{
    private LevelCompletionData lcd;
    public int collectibleNumber;
    public Collider player;

    void OnTriggerEnter(Collider other)
    {
        if(other == player)
        {
            lcd.levelData.secrets[collectibleNumber] = true;
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lcd = LevelCompletionData.instance;
        if(lcd.levelData.secrets[collectibleNumber])
        {
            Destroy(gameObject);
        }
    }
}
