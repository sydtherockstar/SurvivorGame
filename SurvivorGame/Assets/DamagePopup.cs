using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    public static DamagePopup instance; //singleton
    private void Awake() {
        instance = this;
    }
    [SerializeField] GameObject damagePopup;

    public void PostMessage(string text, Vector3 position){
        GameObject go = Instantiate(damagePopup, position, Quaternion.identity, transform);
        go.GetComponent<TMPro.TextMeshPro>().text = text;
    }
}
