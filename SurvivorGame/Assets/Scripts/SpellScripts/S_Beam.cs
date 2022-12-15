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
        GameObject blueBeam = Instantiate(beamPrefab, transform.position, transform.rotation, transform);
        blueBeam.GetComponent<S_BeamDamage>().spellDamage = spellStats.damage + pP.baseDamage;
        blueBeam.transform.localScale = spellStats.scale + pP.spellScale;
    }
    public override void Disable() {}
}