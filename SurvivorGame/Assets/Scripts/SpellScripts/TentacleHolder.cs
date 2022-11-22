using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleHolder : SpellBase
{
    [SerializeField] GameObject tentaclePrefab;
    [SerializeField] float spread = 0.06f;
    GameObject[] enemies;
    Vector3 randomEnemy; 

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
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length < 1){
            randomEnemy = Random.insideUnitCircle * 10;
        }else{
            randomEnemy = enemies[Random.Range(0, enemies.Length)].transform.position;
        }
        
        GameObject tentacle = Instantiate(tentaclePrefab, randomEnemy, Quaternion.identity);
        tentacle.GetComponent<TentacleAction>().spellDamage = spellStats.damage + pP.baseDamage;
        tentacle.GetComponent<TentacleAction>().lifeTime = spellStats.duration;
        tentacle.transform.localScale = spellStats.scale + pP.spellScale;
    }
    public override void Disable(){}
}
