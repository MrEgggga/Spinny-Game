using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float acceleration;
    public float jumpForce;
    public float lowerBound;
    [HideInInspector] public float torqueInput;
    public bool won;
    public bool main = true;
    public bool second = false;
    public Player mainPlayer;
    public UnityEvent onWon;
    public Dictionary<Collider2D, ContactPoint2D> contacts;

    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Collider2D col;

    public PlayerInput input;
    private InputAction move;
    private InputAction jump;
    private InputAction restart;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        contacts.Add(collision.collider, collision.GetContact(0));
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(contacts.ContainsKey(collision.collider)) contacts[collision.collider] = collision.GetContact(0);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        contacts.Remove(collision.collider);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        move = input.actions.FindAction(second ? "P2Move" : "Move");
        jump = input.actions.FindAction(second ? "P2Jump" : "Jump");
        restart = input.actions.FindAction("Restart");

        contacts = new Dictionary<Collider2D, ContactPoint2D>();
    }

    void FixedUpdate()
    {
        torqueInput = move.ReadValue<float>();
        rb.AddTorque(-move.ReadValue<float>() * acceleration, ForceMode2D.Force);
        if(contacts.Count > 0 && jump.ReadValue<float>() == 1f)
        {
            Collider2D firstContact = contacts.Keys.First();
            ContactPoint2D point = contacts[firstContact];
            Vector2 normal = point.normal;
            if(!firstContact.TryGetComponent(out Bouncy _b))
            {
                rb.AddForce(normal * jumpForce, ForceMode2D.Impulse);
                contacts.Remove(firstContact);
                if (firstContact.TryGetComponent(out Rigidbody2D otherRb))
                {
                    otherRb.AddForceAtPosition(-normal * jumpForce, point.point, ForceMode2D.Impulse);
                }
            }
        }

        foreach(KeyValuePair<Collider2D, ContactPoint2D> contactPair in contacts)
        {
            Collider2D contact = contactPair.Key;
            ContactPoint2D point = contactPair.Value;
            if(contact.TryGetComponent(out Sticky sticky))
            {
                rb.AddForceAtPosition(point.normal * sticky.stickiness, point.point);
            }
        }

        if(transform.position.y < lowerBound && (main && !won || !main && !mainPlayer.won))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Update()
    {
        if(restart.ReadValue<float>() == 1f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Win()
    {
        won = true;
        onWon.Invoke();
        if(LevelCompletionData.instance != null) LevelCompletionData.instance.LevelComplete();
    }

    IEnumerator RemoveContact(Collider2D contact, int frames)
    {
        for(int i = 0; i < frames; ++i)
        {
            yield return null;
        }

        contacts.Remove(contact);
    }
}
