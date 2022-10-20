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
    public Vector3 scale;
    public SpellStats(int damage, float timeToAttack, int numberOfAttack, Vector3 scale){
        this.damage = damage;
        this.timeToAttack = timeToAttack;
        this.numberOfAttack = numberOfAttack;
        this.scale = scale;
    }

    internal void Sum(SpellStats spellUpgradeStats)
    {
        this.damage += spellUpgradeStats.damage;
        this.timeToAttack += spellUpgradeStats.timeToAttack;
        this.numberOfAttack += spellUpgradeStats.numberOfAttack;
        this.scale += spellUpgradeStats.scale;
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
