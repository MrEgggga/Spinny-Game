using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Rigidbody2D rb;
    public float rotationSpeed;
    public float acceleration = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.AddTorque((rotationSpeed - rb.angularVelocity) * acceleration, ForceMode2D.Force);
    }
}
