using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_Beam : SpellBase
{
    [SerializeField] GameObject blueBeamPrefab;
    public override void Attack()
    {
        StartCoroutine(AttackProcess());
        blueBeamPrefab.GetComponent<S_BeamDamage>().spellDamage = spellStats.damage + pP.baseDamage; 
    }
    IEnumerator AttackProcess(){
        int duplicatorCount = 0;
        duplicatorCount = spellStats.numberOfAttack + pP.duplicatorCount;
        for(int i = 0; i < spellStats.numberOfAttack; i++){
            blueBeamPrefab.SetActive(true);
        }yield return new WaitForSeconds(0.3f);
    }
}
