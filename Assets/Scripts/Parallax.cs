using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Camera cam;
    public float tilingSize;
    public float parallaxFactor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = cam.transform.position;
        pos.x -= (pos.x % (tilingSize * parallaxFactor) / parallaxFactor);
        pos.y -= (pos.y % (tilingSize * parallaxFactor) / parallaxFactor);
        pos.z = 100;
        transform.position = pos;
    }
}
