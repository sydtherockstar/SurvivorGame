using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class PassiveItemStats
{
    public int armor;
    public int maxHealth;
    /*public int baseDamage;
    public int cooldown;
    public int duplicatorCount;
    public int expUp;
    public int healthRecovery;
    
    public int moveFast;
    public int spellScale;
    public int spellSpeed;*/
    public PassiveItemStats(int armor, int maxHealth){
        this.armor = armor;
        this.maxHealth = maxHealth;
    }

    internal void Sum(PlayerProperties pP)
    {
        pP.armor += armor;
        pP.maxHp += maxHealth;
    }
}
[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string itemName;
    public PassiveItemStats passiveItemStats;
    public List<UpgradeData> passiveUpgrades;
    public void Equip(PlayerProperties pP){
         pP.armor += passiveItemStats.armor;
         pP.maxHp += passiveItemStats.maxHealth;
    }
    public void UnEquip(PlayerProperties pP){
        pP.armor -= passiveItemStats.armor;
        pP.maxHp -= passiveItemStats.maxHealth;
    }
}
