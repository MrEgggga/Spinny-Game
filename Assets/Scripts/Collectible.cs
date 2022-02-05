using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private LevelCompletionData lcd;
    public int collectibleNumber;
    public Collider2D player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other == player)
        {
            Debug.Log("Collected");
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
