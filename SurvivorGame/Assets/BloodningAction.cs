using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodningAction : MonoBehaviour
{
    public int spellDamage;
    public float lifeTime;
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        InterfaceDamagable e = other.GetComponent<InterfaceDamagable>();
        if(e != null){
            e.TakeDamage(spellDamage);
        }
    }
}
