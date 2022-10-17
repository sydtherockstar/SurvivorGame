using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class PassiveItemStats
{
    public int armor;
    public int maxHealth;
    public int baseDamage;
    public int duplicatorCount;
    public float cooldown;
    public int expUp;
    public float healthRecovery;
    public float moveFast;
    public float spellSpeed;
    public Vector3 spellScale;
    
    

    internal void Equip(PlayerProperties pP)
    {
        pP.armor += armor;
        pP.maxHp += maxHealth;
        pP.baseDamage += baseDamage;
        pP.duplicatorCount += duplicatorCount;
        pP.baseCooldown -= cooldown;
        pP.expUpRate += expUp;
        pP.hpRegenerationRate += healthRecovery;
        pP.moveFast += moveFast;
        pP.spellSpeed += spellSpeed;
        pP.spellScale += spellScale;
        
    }
    internal void UnEquip(PlayerProperties pP){
        pP.armor -= armor;
        pP.maxHp -= maxHealth;
        pP.baseDamage = baseDamage;
        pP.duplicatorCount -= duplicatorCount;
        pP.baseCooldown -= cooldown;
        pP.expUpRate -= expUp;
        pP.hpRegenerationRate -= healthRecovery;
        pP.moveFast -= moveFast;
        pP.spellSpeed -= spellSpeed;
        pP.spellScale -= spellScale;
    }
}
[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string itemName;
    public PassiveItemStats passiveItemStats;
    public List<UpgradeData> passiveUpgrades;
    
}
