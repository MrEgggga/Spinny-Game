using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObjects : MonoBehaviour
{
    public Collider2D[] objects;
    private HashSet<Collider2D> toCollect;
    public GameObject toEnable;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(toCollect.Contains(other))
        {
            toCollect.Remove(other);
        }
    }

    void Start()
    {
        toCollect = new HashSet<Collider2D>(objects);
        toEnable.SetActive(false);
    }

    void Update()
    {
        if(toCollect.Count == 0)
        {
            toEnable.SetActive(true);
        }
    }
}
