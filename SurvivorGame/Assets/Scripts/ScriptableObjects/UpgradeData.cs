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
    public string description;
    public Sprite icon;
    public SpellSO spellData;
    public SpellStats spellUpgradeStats;
    public Item passiveItem;
    public PassiveItemStats passiveUpgradeStats;
}
