using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumerangHolder : SpellBase
{
    [SerializeField] GameObject bumerangPrefab;
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
        GameObject bumerang = Instantiate(bumerangPrefab, transform.position, transform.rotation);
        bumerang.GetComponent<BumerangAction>().spellDamage = spellStats.damage + pP.baseDamage;
        bumerang.GetComponent<BumerangAction>().moveSpeed = spellStats.speed + pP.spellSpeed;
        bumerang.GetComponent<BumerangAction>().lifeTime = spellStats.duration;
        bumerang.transform.localScale = spellStats.scale + pP.spellScale;
    }
    public override void Disable(){}
}
