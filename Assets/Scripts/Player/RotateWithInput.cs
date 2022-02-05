using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateWithInput : MonoBehaviour
{
    public float acceleration;
    public PlayerInput input;
    private Rigidbody2D rb;
    private InputAction move;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        move = input.actions.FindAction("Move2");
    }

    private void FixedUpdate()
    {
        rb.AddTorque(-move.ReadValue<float>() * acceleration, ForceMode2D.Force);
    }
}
