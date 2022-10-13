using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RP_Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public int spellDamage;
    [SerializeField] float lifeTime;
    [SerializeField] int hitCount;
    Rigidbody2D rb2d;
    GameObject player;
    Vector2 mousePos;
    Vector2 targetDirection;
    
    

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Shooter");
    }
    private void Start() {
        targetDirection = (player.GetComponent<Aim>().GetMousePosition() - (Vector2)transform.position).normalized;
    }
    void Update()
    {
        transform.position += (Vector3)targetDirection * moveSpeed * Time.deltaTime;
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        InterfaceDamagable e = other.GetComponent<InterfaceDamagable>();
            if(e != null){
                e.TakeDamage(spellDamage);
                hitCount -= 1;
                if(hitCount == 0){
                    Destroy(gameObject);
                }
            }
    }
}
