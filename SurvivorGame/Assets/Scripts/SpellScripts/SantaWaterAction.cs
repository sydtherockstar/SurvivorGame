using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaWaterAction : MonoBehaviour
{
    GameObject[] enemies;
    Vector3 randomEnemy; 
    public float moveSpeed;
    public int spellDamage;
    public float lifeTime;
    [SerializeField] float runTime = 1f;
    Animator animator;
    private void Awake() {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        this.GetComponent<Collider2D>().enabled = false;
        randomEnemy = Random.insideUnitCircle * 15;
    }

    void Update()
    {   
        transform.position += randomEnemy * moveSpeed * Time.deltaTime;
        runTime -= Time.deltaTime;
        if(runTime <= 0){
            StartCoroutine(LifeTimeExecute());
            animator.SetTrigger("isExplode");
            moveSpeed = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        InterfaceDamagable e = other.GetComponent<InterfaceDamagable>();
        if(e != null){
            DamagePopup.instance.PostMessage(spellDamage.ToString(), other.transform.position);
            e.TakeDamage(spellDamage);
        }
    }
    IEnumerator LifeTimeExecute(){
        this.GetComponent<Collider2D>().enabled = true;
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0){
            Destroy(gameObject);
        }
        yield return new WaitForSeconds(0.1f);
    }
}
