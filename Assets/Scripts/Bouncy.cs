using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    public float bounciness;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Rigidbody2D rb))
        {
            rb.AddForce(-collision.GetContact(0).normal * bounciness, ForceMode2D.Impulse);
        }
    }
}
