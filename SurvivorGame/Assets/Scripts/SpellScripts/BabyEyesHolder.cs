using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyEyesHolder : SpellBase
{
    [SerializeField] GameObject babyEyesPrefab;
    float radius;    
    GameObject babyEyes;
    public override void Attack()
    {
        int duplicatorCount = 0;
        duplicatorCount = spellStats.numberOfAttack + pP.duplicatorCount;
        radius = 2 + (duplicatorCount / 3);
        Vector3[] positions =  new Vector3[] 
        {new Vector3(radius,0f,0f), new Vector3(-radius,0f,0f),
            new Vector3(0f,radius,0f), new Vector3(0f,-radius,0f),
                new Vector3(GetAngleRadius(45),GetAngleRadius(45),0f), 
                    new Vector3(-GetAngleRadius(45),GetAngleRadius(45),0f),
                        new Vector3(-GetAngleRadius(45),-GetAngleRadius(45),0f), 
                            new Vector3(GetAngleRadius(45),-GetAngleRadius(45),0f),};
        
        for(int i = 0; i < duplicatorCount; i++){
            SpawnEye(player.transform.position + positions[i]);
        }
    }
    private float GetAngleRadius(int angle){
        double angleRadius = radius * Math.Cos(angle * (Math.PI / 180));
        return (float)angleRadius;
    }
    private void SpawnEye(Vector3 position){
        babyEyes = Instantiate(babyEyesPrefab, position, Quaternion.identity);
        babyEyes.transform.parent = player.transform;
        babyEyes.GetComponent<BabyEyesMovement>().spellDamage = spellStats.damage + pP.baseDamage;
        babyEyes.GetComponent<BabyEyesMovement>().moveSpeed = spellStats.speed + pP.spellSpeed;
        babyEyes.GetComponent<BabyEyesMovement>().lifeTime = spellStats.duration;
        babyEyes.transform.localScale = spellStats.scale + pP.spellScale; 
    }
    public override void Disable(){}
}
