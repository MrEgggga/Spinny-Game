using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float lowerBound;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < lowerBound) Destroy(gameObject);
    }
}
