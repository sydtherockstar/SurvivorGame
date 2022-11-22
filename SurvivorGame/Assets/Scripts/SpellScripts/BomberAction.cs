using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberAction : MonoBehaviour
{
    GameObject[] enemies;
    Vector3 randomEnemy; 
    public float moveSpeed;
    public int spellDamage;
    public float lifeTime;
    [SerializeField] float runTime = 1f;
    Animator animator;
    CircleCollider2D cC2d;
    private void Awake() {
        cC2d = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        cC2d.enabled = false;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length < 1){
            randomEnemy = Random.insideUnitCircle * 10;
        }else{
            randomEnemy = (enemies[Random.Range(0, enemies.Length)].transform.position - transform.position).normalized;
        }
    }

    void Update()
    {   
        transform.position += randomEnemy * moveSpeed * Time.deltaTime;
        runTime -= Time.deltaTime;
        if(runTime <= 0){
            moveSpeed = 0;
            Explode();
        }
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0){
            DestroyGO();
        }
    }
    void Explode(){
        cC2d.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        InterfaceDamagable e = other.GetComponent<InterfaceDamagable>();
            if(e != null){
                animator.SetTrigger("isExplode");
                e.TakeDamage(spellDamage);
                Invoke("DestroyGO", 0.4f);
        }
    }
    void DestroyGO(){
        Destroy(gameObject);
    }
}
