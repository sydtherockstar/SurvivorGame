using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleAction : MonoBehaviour
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
            DamagePopup.instance.PostMessage(spellDamage.ToString(), other.transform.position);
            e.TakeDamage(spellDamage);
        }
    }
}
