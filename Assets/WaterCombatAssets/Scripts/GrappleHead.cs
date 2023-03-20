using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHead : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trash"))
        {
            //Debug.Log("Hit Detected");
            other.transform.SetParent(transform);
            other.transform.localPosition = Vector3.zero;
        }
    }
}
