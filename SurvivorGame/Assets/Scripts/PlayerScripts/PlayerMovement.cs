using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Vector2 rawInput;
    private Vector2 getterInput = new Vector2(1,0);
    [SerializeField] float moveSpeed;
    Rigidbody2D rb2d;
    PlayerProperties pP;
    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        pP = GetComponent<PlayerProperties>();
    }
    private void FixedUpdate() {
        Move();
    }

    private void Move(){
        if (rawInput != new Vector2(0,0)){
            getterInput = rawInput;
        }
        Vector3 movementVector = rawInput * (moveSpeed + pP.moveFast);
        rb2d.velocity = movementVector;
    }
    void OnMove(InputValue value) {   
        rawInput = value.Get<Vector2>(); 
    }
    public Vector2 GetPlayerMovement(){
        return getterInput;
    }
}
