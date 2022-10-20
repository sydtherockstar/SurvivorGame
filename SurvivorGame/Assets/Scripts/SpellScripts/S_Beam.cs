using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_Beam : SpellBase
{
    [SerializeField] GameObject beamPrefab;
    public override void Attack()
    {
        beamPrefab.transform.localScale = spellStats.scale + pP.spellScale;
        beamPrefab.GetComponent<S_BeamDamage>().spellDamage = spellStats.damage + pP.baseDamage;
        beamPrefab.SetActive(true); 
        /*this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<Collider2D>().enabled = true;
        this.GetComponent<Animator>().enabled = true;*/
    }
    public override void Disable(){
        beamPrefab.SetActive(false); 
        /*this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<Collider2D>().enabled = false;
        this.GetComponent<Animator>().enabled = false;*/
    } 
}
