using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        PlayerProperties pP = other.GetComponent<PlayerProperties>();
        if (pP != null){
            GetComponent<InterfacePickup>().OnPickUp(pP);
            Destroy(gameObject);
        } 
    }
}
