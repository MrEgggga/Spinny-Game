using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform objectToFollow;
    private Vector3 offset;
    public bool goToObject;

    // Start is called before the first frame update
    void Start()
    {
        if(goToObject)
        {
            offset = Vector3.back * 10;
            transform.position = objectToFollow.position + offset;
            return;
        }
        offset = transform.position - objectToFollow.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = objectToFollow.position + offset;
        // transform.rotation = objectToFollow.rotation; // this is bad, don't uncomment
    }
}
