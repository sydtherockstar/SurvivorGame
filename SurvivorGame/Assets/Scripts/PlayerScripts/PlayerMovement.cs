using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Vector2 rawInput;
    [SerializeField] float moveSpeed;
    Rigidbody2D rb2d;
    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {
        Move();
    }

    private void Move(){
        Vector3 movementVector = rawInput * moveSpeed;
        rb2d.velocity = movementVector;
    }
    void OnMove(InputValue value) {   
        rawInput = value.Get<Vector2>(); 
    }
}
