using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BeamDamage : MonoBehaviour
{

    public int spellDamage;
    private void OnTriggerEnter2D(Collider2D other) {
        
            InterfaceDamagable e = other.GetComponent<InterfaceDamagable>();
            if(e != null){
                e.TakeDamage(spellDamage);
            }
    }    
}
