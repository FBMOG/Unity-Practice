using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{

    private void OnTiggerStay(Collider other)
    {
         Debug.Log("Hello: " + this.gameObject.name);
        if(other.gameObject.tag == "Player")
        {
            if(Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
            }
        }
    }

  
}
