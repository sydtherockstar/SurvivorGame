using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMessage : MonoBehaviour
{
    [SerializeField] float popupLeaveTimer;
    RectTransform rectTransform;
    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
    }
    private void Update() {
        rectTransform.position += new Vector3(0.01f, 0.01f, 0);
        popupLeaveTimer -= Time.deltaTime;
        if(popupLeaveTimer < 0f){
            Destroy(gameObject);
        }
    }
}
