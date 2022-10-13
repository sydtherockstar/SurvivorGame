using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellBase : MonoBehaviour
{
    public SpellSO spellData;
    public SpellStats spellStats; 
    float timer;
    public void Update() {
        timer -= Time.deltaTime;
        if(timer < 0f){
            Attack();
            timer = spellStats.timeToAttack;
        }
    }
    public virtual void SetData(SpellSO sd){
        spellData = sd;
        spellStats = new SpellStats(sd.spellStats.damage, sd.spellStats.timeToAttack, sd.spellStats.numberOfAttack);
    }
    public abstract void Attack();
    public void Upgrade(UpgradeData upgradeData){
        spellStats.Sum(upgradeData.spellUpgradeStats);
    }
}
