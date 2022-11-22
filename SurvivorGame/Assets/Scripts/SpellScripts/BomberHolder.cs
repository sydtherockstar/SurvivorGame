using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberHolder : SpellBase
{
    [SerializeField] GameObject bomberPrefab;
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
        GameObject bomber = Instantiate(bomberPrefab, transform.position, transform.rotation);
        bomber.GetComponent<BomberAction>().spellDamage = spellStats.damage + pP.baseDamage;
        bomber.GetComponent<BomberAction>().moveSpeed = spellStats.speed + pP.spellSpeed;
        bomber.GetComponent<BomberAction>().lifeTime = spellStats.duration;
        bomber.transform.localScale = spellStats.scale + pP.spellScale;
    }
    public override void Disable(){}
}
