using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public LevelList levelList;
    public TextMeshProUGUI[] text;
    public TextMeshProUGUI[] goldTimeInfo;
    public float goldTime;
    public bool gold;
    public UnityEvent onGoldLost;
    private bool stop;
    public float elapsed;
    public bool secret = false;

    private void Start()
    {
        elapsed = 0f;
        stop = false;
        gold = true;
        
        Level lv = secret ? levelList.secretLevels.First(l => l.buildIndex == SceneManager.GetActiveScene().buildIndex) : levelList.levels.First(l => l.buildIndex == SceneManager.GetActiveScene().buildIndex);
        goldTime = lv.goldTime;

        foreach(TextMeshProUGUI t in goldTimeInfo)
        {
            t.text = string.Format("[Gold time is {0:N3}]", goldTime);
        }
    }

    void Update()
    {
        if (!stop)
        {
            elapsed += Time.deltaTime;
            foreach (TextMeshProUGUI t in text)
            {
                t.text = string.Format("{0:N3}", elapsed);
            }

            if(gold && elapsed > goldTime)
            {
                gold = false;
                onGoldLost.Invoke();
            }
        }
    }

    public void StopTimer()
    {
        stop = true;
    }
}
