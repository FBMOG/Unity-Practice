using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHead : MonoBehaviour
{  
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip shoot;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trash") || other.CompareTag("Fish"))
        {
            _source.PlayOneShot(shoot);
            other.transform.SetParent(transform);
            other.transform.localPosition = Vector3.zero;
            
            // set isCaught to true on the FishMovement component attached to the other object
            FishMovement fishMovement = other.GetComponent<FishMovement>();
            if (fishMovement != null)
            {
                fishMovement.isCaught = true;
                fishMovement.GetComponent<BoxCollider2D>().enabled = false;
            }
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}


