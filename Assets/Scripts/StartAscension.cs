using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAscension : MonoBehaviour
{
    public GameObject ascension;
    public GameObject canvas;

    void OnTriggerEnter2D(Collider2D other)
    {
        ascension.SetActive(true);
        canvas.SetActive(false);
    }

    void Start()
    {
        ascension.SetActive(false);
    }
}
