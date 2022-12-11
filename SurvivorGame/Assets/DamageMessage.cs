using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMessage : MonoBehaviour
{
    [SerializeField] float popupLeaveTimer;
    private void Update() {
        popupLeaveTimer -= Time.deltaTime;
        if(popupLeaveTimer < 0f){
            Destroy(gameObject);
        }
    }
}
