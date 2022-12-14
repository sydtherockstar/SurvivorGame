using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumerangAction : MonoBehaviour
{
    public float moveSpeed;
    public int spellDamage;
    public float lifeTime;
    [SerializeField] int hitCount;
    EnemyRadar enemyRadar;
    Vector3 targetDirection;
    
    private void Awake() {
        enemyRadar = FindObjectOfType<EnemyRadar>();
    }
    private void Start() {
        targetDirection = (enemyRadar.FindClosestEnemy().position - transform.position).normalized;
    }
    void Update()
    {
        transform.position += targetDirection * moveSpeed * Time.deltaTime;
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        InterfaceDamagable e = other.GetComponent<InterfaceDamagable>();
        if(e != null){
            DamagePopup.instance.PostMessage(spellDamage.ToString(), other.transform.position);
            e.TakeDamage(spellDamage);
            targetDirection = (enemyRadar.FindSecondClosestEnemy().position - transform.position).normalized;
            hitCount -= 1;
            if(hitCount == 0){
                Destroy(gameObject);
            }
        }
    }
}
