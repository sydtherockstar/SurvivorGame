using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpellStats
{
    public int damage;
    public float timeToAttack;
    public int numberOfAttack;
    public SpellStats(int damage, float timeToAttack, int numberOfAttack){
        this.damage = damage;
        this.timeToAttack = timeToAttack;
        this.numberOfAttack = numberOfAttack;
    }

    internal void Sum(SpellStats spellUpgradeStats)
    {
        this.damage += spellUpgradeStats.damage;
        this.timeToAttack += spellUpgradeStats.timeToAttack;
        this.numberOfAttack += spellUpgradeStats.numberOfAttack;
    }
}
[CreateAssetMenu]
public class SpellSO : ScriptableObject
{
    public string Name;
    public SpellStats spellStats;
    public GameObject spellBasePrefab;
    public List<UpgradeData> upgrades;
}
