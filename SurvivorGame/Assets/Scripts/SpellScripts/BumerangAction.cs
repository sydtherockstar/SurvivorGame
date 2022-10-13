using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumerangAction : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public int spellDamage;
    [SerializeField] float lifeTime;
    [SerializeField] int hitCount;
    GameObject player;
    Vector2 targetDirection;
    Transform closestEnemy;

     private void Awake() {
        player = GameObject.Find("Shooter");
    }
    private void Start() {
        
    }
    void Update()
    {
        closestEnemy = player.GetComponent<EnemyRadar>().GetClosestEnemy();
        targetDirection = ((Vector2)closestEnemy.position - (Vector2)transform.position).normalized;
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
