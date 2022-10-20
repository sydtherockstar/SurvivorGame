using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodpoolAction : SpellBase
{
    public int spellDamage;
    private void OnTriggerEnter2D(Collider2D other) {
        InterfaceDamagable e = other.GetComponent<InterfaceDamagable>();
        if(e != null){
            e.TakeDamage(spellDamage);
        }
    }
    public override void Attack(){
        transform.localScale = spellStats.scale + pP.spellScale;
        spellDamage = spellStats.damage + pP.baseDamage; 
        this.GetComponent<Collider2D>().enabled = true;
    }
    public override void Disable(){
        this.GetComponent<Collider2D>().enabled = false;
    }
}
