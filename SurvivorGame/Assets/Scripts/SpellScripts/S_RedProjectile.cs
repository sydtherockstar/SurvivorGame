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
        
        for(int i = 0; i < spellStats.numberOfAttack; i++){
            Vector3 position = transform.position;
            if(spellStats.numberOfAttack > 1){
                position.y -= (spread * spellStats.numberOfAttack - 1) / 2;
                position.y += i * spread;
            }
            GameObject fireball = Instantiate(redProjectilePrefab, position, transform.rotation);
            fireball.GetComponent<RP_Movement>().spellDamage = spellStats.damage;
        }
        
    }
}
