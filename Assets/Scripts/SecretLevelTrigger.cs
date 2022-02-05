using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretLevelTrigger : MonoBehaviour
{
    public int secretLevelNumber;
    public GameObject player;
    public LevelList levelList;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            LevelCompletionData.instance.levelData.secretLevelData[secretLevelNumber].unlocked = true;
            SceneManager.LoadScene(levelList.secretLevels[secretLevelNumber].buildIndex);
        }
    }
}
