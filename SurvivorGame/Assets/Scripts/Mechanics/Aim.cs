using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Aim : MonoBehaviour
{
    float angle;
    Vector2 mousePos;
    private void LateUpdate() {
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 lookDir = mousePos - (Vector2)transform.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3 (0, 0, angle);
    }
    public Vector2 GetMousePosition(){
        return mousePos;
    }
}
