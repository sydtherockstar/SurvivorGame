using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BeamDamage : MonoBehaviour
{
    public int spellDamage;
    private void OnTriggerStay2D(Collider2D other) {
        InterfaceDamagable e = other.GetComponent<InterfaceDamagable>();
        if(e != null){
            DamagePopup.instance.PostMessage(spellDamage.ToString(), other.transform.position);
            e.TakeDamage(spellDamage);
        }
    }    
}
