using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    [SerializeField] Transform spellContainer;
    [SerializeField] SpellSO startingSpell;
    List<SpellBase> spells;
    private void Awake() {
        spells = new List<SpellBase>();
    }

    private void Start() {
        AddSpell(startingSpell);
    }
    public void AddSpell(SpellSO spellSO){
        GameObject spellGameObject = Instantiate(spellSO.spellBasePrefab, spellContainer);
        SpellBase spellBase = spellGameObject.GetComponent<SpellBase>();
        spellBase.SetData(spellSO);
        spells.Add(spellBase);
        Level level = GetComponent<Level>();
        if(level != null){
            level.AddUpgradeToListOfAvailableUpgrades(spellSO.upgrades);
        }
    }

    public void UpgradeSpell(UpgradeData upgradeData)
    {
        SpellBase spellToUpgrade = spells.Find(sd => sd.spellData == upgradeData.spellData);
        spellToUpgrade.Upgrade(upgradeData);
    }
}
