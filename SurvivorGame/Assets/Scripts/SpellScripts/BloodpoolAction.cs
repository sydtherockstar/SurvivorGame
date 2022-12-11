using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodpoolAction : SpellBase
{
    GameObject bloodpoolContainer;
    private void Start() {
        bloodpoolContainer = GameObject.FindGameObjectWithTag("Player");
        this.transform.parent = bloodpoolContainer.transform;
    }
    public int spellDamage;
    private void OnTriggerEnter2D(Collider2D other) {
        InterfaceDamagable e = other.GetComponent<InterfaceDamagable>();
        if(e != null){
            DamagePopup.instance.PostMessage(spellDamage.ToString(), other.transform.position);
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
