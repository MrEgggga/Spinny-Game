using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouched : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        transform.parent.gameObject.SetActive(false);
    }
}
