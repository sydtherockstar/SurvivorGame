using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ButtonClickEvent : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Sprite buttonClick;
    [SerializeField] Sprite defButton;

    private void Awake() {
        button = GetComponent<Button>();
    }
    public void OnClick(InputValue value){
        Debug.Log(value);
        if(value.isPressed){
            Debug.Log(value);
            button.image.sprite = buttonClick;
        }else{
            button.image.sprite = defButton;
        }
    }
}
