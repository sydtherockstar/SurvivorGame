using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumerangHolder : SpellBase
{
    [SerializeField] GameObject bumerangPrefab;
    [SerializeField] float spread = 0.5f;
    float radius = 0f;

    public override void Attack()
    {
        int duplicatorCount = 0;
        duplicatorCount = spellStats.numberOfAttack + pP.duplicatorCount;
        for(int i = 0; i < duplicatorCount; i++){
            Vector3 position = transform.position;
            if(duplicatorCount > 1){
                position.y -= (spread * duplicatorCount - 1) / 1.2f;
                position.y += i * spread;
                position.x -= (spread * duplicatorCount - 1) / 1.2f;
                position.x += i * spread;
            }
            GameObject bumerang = Instantiate(bumerangPrefab, position, transform.rotation);
            bumerang.GetComponent<BumerangAction>().spellDamage = spellStats.damage + pP.baseDamage;
            bumerang.GetComponent<BumerangAction>().moveSpeed = spellStats.speed + pP.spellSpeed;
            bumerang.transform.localScale += pP.spellScale;
        }
    }
     private float GetAngleRadius(int angle){
        double angleRadius = radius * Math.Cos(angle * (Math.PI / 180));
        return (float)angleRadius;
    }
    public override void Disable(){}
}
