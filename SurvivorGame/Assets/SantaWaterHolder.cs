using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaWaterHolder : SpellBase
{
    [SerializeField] GameObject santaPrefab;
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
        GameObject santa = Instantiate(santaPrefab, transform.position, transform.rotation);
        santa.GetComponent<SantaWaterAction>().spellDamage = spellStats.damage + pP.baseDamage;
        santa.GetComponent<SantaWaterAction>().moveSpeed = spellStats.speed + pP.spellSpeed;
        santa.GetComponent<SantaWaterAction>().lifeTime = spellStats.duration;
        santa.transform.localScale = spellStats.scale + pP.spellScale;
    }
    public override void Disable(){}
}
