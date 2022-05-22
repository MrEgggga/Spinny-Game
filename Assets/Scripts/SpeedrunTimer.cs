using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedrunTimer : MonoBehaviour
{
    public static SpeedrunTimer instance;
    public Canvas canvas;
    public TextMeshProUGUI text;
    public float elapsed;
    private bool timerRunning;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(canvas.gameObject);
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        if(instance != this)
        {
            Destroy(instance.canvas.gameObject);
            instance = this;
        }
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if(timerRunning) elapsed += Time.deltaTime;
        text.text = string.Format("{0:N3}", elapsed);
    }

    public void StartTimer()
    {
        timerRunning = true;
    }

    public void StopTimer()
    {
        timerRunning = false;
    }
}
