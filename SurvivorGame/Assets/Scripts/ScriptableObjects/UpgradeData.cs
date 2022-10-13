using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    SpellUpgrade,
    PassiveUpgrade,
    SpellUnlock,
    PassiveUnlock
}
[CreateAssetMenu]
public class UpgradeData : ScriptableObject
{
    public UpgradeType upgradeType;
    public string Name;
    public Sprite icon;
    public SpellSO spellData;
    public SpellStats spellUpgradeStats;
}
