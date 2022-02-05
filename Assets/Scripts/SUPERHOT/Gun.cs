using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public float bulletForce;
    public float aimAccel;
    public GameObject bullet;
    public Rigidbody2D rb;
    public PlayerInput input;
    private InputAction shoot;
    private bool shooting;
    private InputAction _throw;
    private InputAction mousePos;
    private float cooldown;

    void Start()
    {
        shoot = input.actions.FindAction("Shoot");
        _throw = input.actions.FindAction("Throw");
        mousePos = input.actions.FindAction("MousePos");
    }

    void FixedUpdate()
    {
        cooldown -= Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 diff = Camera.main.ScreenToWorldPoint(mousePos.ReadValue<Vector2>()) - transform.position;
        float targetRotation = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        float rotDiff = (targetRotation - transform.rotation.eulerAngles.z) % 360;
        if(rotDiff > 180) rotDiff -= 360;
        if(rotDiff < -180) rotDiff += 360;
        rb.MoveRotation(targetRotation);

        if(shoot.ReadValue<float>() >= 0.5f && !shooting)
        {
            Rigidbody2D bulletRb = Instantiate(bullet, transform.position + transform.right, transform.rotation).GetComponent<Rigidbody2D>();
            bulletRb.AddRelativeForce(bulletForce * Vector2.right, ForceMode2D.Impulse);
            rb.AddForce(-bulletForce * transform.right, ForceMode2D.Impulse);
        }

        shooting = (shoot.ReadValue<float>() >= 0.5f);
    }
}
