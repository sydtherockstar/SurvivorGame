using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpellStats
{
    public int damage;
    public float speed;
    public float timeToAttack;
    public float duration;
    public int numberOfAttack;
    public Vector3 scale;
    public SpellStats(int damage, float speed, float timeToAttack, float duration, int numberOfAttack, Vector3 scale){
        this.damage = damage;
        this.speed = speed;
        this.timeToAttack = timeToAttack;
        this.duration = duration;
        this.numberOfAttack = numberOfAttack;
        this.scale = scale;
    }

    internal void Sum(SpellStats spellUpgradeStats)
    {
        this.damage += spellUpgradeStats.damage;
        this.speed += spellUpgradeStats.speed;
        this.timeToAttack += spellUpgradeStats.timeToAttack;
        this.duration += spellUpgradeStats.duration;
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
