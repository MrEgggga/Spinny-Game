using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public float timeScale = 0.7f;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.simulationMode = SimulationMode2D.Script;
    }

    // Update is called once per frame
    void Update()
    {
        timeScale = Mathf.Abs(player.torqueInput) > 0.5f ? 1f : 0.1f;
        Physics2D.Simulate(Time.deltaTime * timeScale);
    }
}
