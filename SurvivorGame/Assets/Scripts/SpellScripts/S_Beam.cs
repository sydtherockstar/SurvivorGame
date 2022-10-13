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
        blueBeamPrefab.GetComponent<S_BeamDamage>().spellDamage = spellStats.damage; 
    }
    IEnumerator AttackProcess(){
        for(int i = 0; i < spellStats.numberOfAttack; i++){
            blueBeamPrefab.SetActive(true);
        }yield return new WaitForSeconds(0.3f);
    }
}
