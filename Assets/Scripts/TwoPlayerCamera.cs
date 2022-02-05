using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlayerCamera : MonoBehaviour
{
    public Transform p1;
    public Transform p2;
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        transform.position = (p1.position + p2.position) / 2 - Vector3.forward * 10f;
        cam.orthographicSize = Mathf.Max(10.0f, (p1.position - p2.position).magnitude / 2);
    }
}
