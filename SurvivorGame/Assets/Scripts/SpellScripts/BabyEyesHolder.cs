using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyEyesHolder : SpellBase
{
    [SerializeField] GameObject babyEyesPrefab;
    [SerializeField] float d = 2f;
     [SerializeField] float spread = 5f;
    public override void Attack()
    {
        Vector3[] positions =  new Vector3[] {new Vector3(d,0f,0f), new Vector3(-d,0f,0f),
                                                new Vector3(0f,d,0f), new Vector3(0f,-d,0f),
                                                    new Vector3(d,d,0f), new Vector3(-d,d,0f),
                                                        new Vector3(d,-d,0f), new Vector3(-d,-d,0f),};
        int duplicatorCount = 0;
        duplicatorCount = spellStats.numberOfAttack + pP.duplicatorCount;
        for(int i = 0; i < duplicatorCount; i++){
            Vector3 position = transform.position + new Vector3(2,0f,0f);
            if(duplicatorCount > 1){
                position.y -= (spread * duplicatorCount - 1) / 2;
                position.y += i * spread;
            }
            SpawnEye(player.transform.position + positions[i]);
        }
    }
    private void SpawnEye(Vector3 position){
        GameObject babyEyes = Instantiate(babyEyesPrefab, position, Quaternion.identity);
        babyEyes.transform.parent = player.transform;
        babyEyes.GetComponent<BabyEyesMovement>().spellDamage = spellStats.damage + pP.baseDamage;
        babyEyes.GetComponent<BabyEyesMovement>().moveSpeed += pP.spellSpeed;
        babyEyes.transform.localScale = spellStats.scale + pP.spellScale; 
    }
    public override void Disable(){}
}
