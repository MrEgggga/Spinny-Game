using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnTrigger : MonoBehaviour
{
    public GameObject toEnable;

    void OnTriggerEnter2D(Collider2D other)
    {
        toEnable.SetActive(true);
    }

    void Start()
    {
        toEnable.SetActive(false);
    }
}
