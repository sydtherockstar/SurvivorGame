using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicWaveHolder : SpellBase
{
    [SerializeField] GameObject sonicWavePrefab;
    [SerializeField] float spread = 0.5f;

    public override void Attack()
    {
        int duplicatorCount = 0;
        duplicatorCount = spellStats.numberOfAttack + pP.duplicatorCount;
        for(int i = 0; i < duplicatorCount; i++){
            Vector3 position = transform.position;
            if(duplicatorCount > 1){
                if(pM.GetPlayerMovement().x != 0){
                    position.y -= (spread * duplicatorCount - 1) / 2f;
                    position.y += i * spread;
                }
                if(pM.GetPlayerMovement().y != 0){
                    position.x -= (spread * duplicatorCount - 1) / 2f;
                    position.x += i * spread;
                }
                
            }
            GameObject sonicWave = Instantiate(sonicWavePrefab, position, Quaternion.identity);
            if(pM.GetPlayerMovement().y != 0){
                var rotationVector = sonicWave.transform.rotation.eulerAngles;
                rotationVector.z = 90;
                sonicWave.transform.rotation = Quaternion.Euler(rotationVector);
            }
            sonicWave.GetComponent<SonicWaveMovement>().spellDamage = spellStats.damage + pP.baseDamage;
            sonicWave.GetComponent<SonicWaveMovement>().moveSpeed = spellStats.speed + pP.spellSpeed;
            sonicWave.transform.localScale += pP.spellScale;
        }
    }
    public override void Disable(){}
}
