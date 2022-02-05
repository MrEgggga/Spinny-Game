using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public float timeBetweenPoints;
    public float startFactor;
    public bool startDirection;
    private float lerpFactor;
    private bool direction;

    void Start()
    {
        lerpFactor = startFactor;
        direction = startDirection;
    }

    private void FixedUpdate()
    {
        if (direction)
        {
            lerpFactor += Time.fixedDeltaTime / timeBetweenPoints;
            if(lerpFactor > 1)
            {
                lerpFactor = 1;
                direction = false;
            }
        }
        else
        {
            lerpFactor -= Time.fixedDeltaTime / timeBetweenPoints;
            if (lerpFactor < 0)
            {
                lerpFactor = 0;
                direction = true;
            }
        }

        transform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0, 1, lerpFactor));
    }
}
