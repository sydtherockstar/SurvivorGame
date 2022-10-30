using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_RedProjectile : SpellBase 
{
    [SerializeField] GameObject redProjectilePrefab;
    [SerializeField] float spread = 0.06f;

    public override void Attack()
    {
        StartCoroutine(SpawnSpell());
    }
    IEnumerator SpawnSpell(){
        int duplicatorCount = 0;
        duplicatorCount = spellStats.numberOfAttack + pP.duplicatorCount;
        for(int i = 0; i < duplicatorCount; i++){
            if(duplicatorCount > 1){
                SpawningSpell();
                yield return new WaitForSeconds(spread);
            }else{
                SpawningSpell();
            }
        }
    }
    void SpawningSpell(){
        GameObject fireball = Instantiate(redProjectilePrefab, transform.position, transform.rotation);
        fireball.GetComponent<RP_Movement>().spellDamage = spellStats.damage + pP.baseDamage;
        fireball.GetComponent<RP_Movement>().moveSpeed = spellStats.speed + pP.spellSpeed;
        fireball.GetComponent<RP_Movement>().lifeTime = spellStats.duration;
        fireball.transform.localScale = spellStats.scale + pP.spellScale;
    }
    public override void Disable(){}
}
