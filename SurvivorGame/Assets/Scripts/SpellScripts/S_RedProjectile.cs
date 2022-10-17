using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_RedProjectile : SpellBase 
{
    [SerializeField] GameObject redProjectilePrefab;
    [SerializeField] float spread = 0.5f;

    public override void Attack()
    {
        int duplicatorCount = 0;
        duplicatorCount = spellStats.numberOfAttack + pP.duplicatorCount;
        for(int i = 0; i < duplicatorCount; i++){
            Vector3 position = transform.position;
            if(duplicatorCount > 1){
                position.y -= (spread * duplicatorCount - 1) / 2;
                position.y += i * spread;
            }
            GameObject fireball = Instantiate(redProjectilePrefab, position, transform.rotation);
            fireball.GetComponent<RP_Movement>().spellDamage = spellStats.damage + pP.baseDamage;
            fireball.GetComponent<RP_Movement>().moveSpeed += pP.spellSpeed;
            fireball.transform.localScale += pP.spellScale;
        }
        
    }
}
