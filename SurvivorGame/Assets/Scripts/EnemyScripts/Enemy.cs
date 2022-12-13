using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, InterfaceDamagable
{
    [SerializeField] float moveSpeed;
    [SerializeField] int hp;
    [SerializeField] int damage;
    [SerializeField] int experience;
    GameObject targetGameObject;
    Transform targetDestination;
    PlayerProperties targetPlayer;
    Rigidbody2D rb2d;
    Animator animator;
    private void Awake() {
        animator = GetComponent<Animator>();
        targetGameObject = GameObject.Find("Player");
        targetDestination = targetGameObject.transform;
        rb2d = GetComponent<Rigidbody2D>();
        targetPlayer = targetGameObject.GetComponent<PlayerProperties>();
    }
    private void FixedUpdate() {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rb2d.velocity = direction * moveSpeed;
    }
    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject == targetGameObject){
            Attack();
        }
    }

    private void Attack()
    {
         if(targetPlayer != null){
            targetPlayer.TakeDamage(damage);
         }
    }
    public void TakeDamage(int damage){
        hp -= damage;
        if(hp <= 0){
            EnemyDied();
        }else{
            animator.SetBool("isDamaged", true);
        }
    }
    void EnemyDied(){
        this.GetComponent<Collider2D>().enabled = false;
        moveSpeed = 0;
        damage = 0;
        animator.SetTrigger("isDead");
        targetGameObject.GetComponent<Level>().AddExperience(experience);
    }
}
