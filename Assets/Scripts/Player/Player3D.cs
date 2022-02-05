using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player3D : MonoBehaviour
{
    public float acceleration;
    public float jumpForce;
    public float lowerBound;
    public bool won;
    public bool main = true;
    public Player mainPlayer;
    public UnityEvent onWon;
    public Dictionary<Collider, ContactPoint> contacts;

    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public Collider col;

    public PlayerInput input;
    private InputAction move;
    private InputAction moveZ;
    private InputAction jump;
    private InputAction restart;

    private void OnCollisionEnter(Collision collision)
    {
        contacts.Add(collision.collider, collision.GetContact(0));
    }

    private void OnCollisionStay(Collision collision)
    {
        if(contacts.ContainsKey(collision.collider)) contacts[collision.collider] = collision.GetContact(0);
    }

    private void OnCollisionExit(Collision collision)
    {
        contacts.Remove(collision.collider);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

        move = input.actions.FindAction("Move3D");
        moveZ = input.actions.FindAction("Move3DZ");
        jump = input.actions.FindAction("Jump");
        restart = input.actions.FindAction("Restart");

        contacts = new Dictionary<Collider, ContactPoint>();
    }

    void FixedUpdate()
    {
        Vector3 movement = (Vector3)move.ReadValue<Vector2>() + Vector3.forward * moveZ.ReadValue<float>();
        Vector3 rotation = Vector3.back * movement.x + Vector3.right * movement.y + Vector3.up * movement.z;
        rb.AddTorque(rotation * acceleration, ForceMode.Force);
        if(contacts.Count > 0 && jump.ReadValue<float>() == 1f)
        {
            Collider firstContact = contacts.Keys.First();
            ContactPoint point = contacts[firstContact];
            Vector3 normal = point.normal;
            if(!firstContact.TryGetComponent(out Bouncy _b))
            {
                rb.AddForce(normal * jumpForce, ForceMode.Impulse);
                contacts.Remove(firstContact);
                if (firstContact.TryGetComponent(out Rigidbody otherRb))
                {
                    otherRb.AddForceAtPosition(-normal * jumpForce, point.point, ForceMode.Impulse);
                }
            }        }

        foreach(KeyValuePair<Collider, ContactPoint> contact in contacts)
        {
            if(contact.Key.TryGetComponent(out Sticky sticky))
            {
                rb.AddForceAtPosition(contact.Value.normal * sticky.stickiness, contact.Value.point);
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
}
