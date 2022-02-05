using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCenterOfMass : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 com;

    // Start is called before the first frame update
    void Start()
    {
        rb.centerOfMass = com;
    }

    // change
}
