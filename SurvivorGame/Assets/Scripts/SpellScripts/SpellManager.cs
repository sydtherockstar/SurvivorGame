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
            level.AddUpgradeToListOfAvailableUpgrades(spellSO.upgrades[0]);
        }
    }
    public void CheckLevelUp(SpellSO spellSO, UpgradeData upgradeData){
        int i = spellSO.upgrades.IndexOf(upgradeData);
        Level level = GetComponent<Level>();
        if(level != null){
            if(upgradeData == spellSO.upgrades[i]){
                if(i <= (spellSO.upgrades.Count - 2)){
                    level.AddUpgradeToListOfAvailableUpgrades(spellSO.upgrades[i + 1]);
                }else { return; }
            }
            
        }
    }

    public void UpgradeSpell(UpgradeData upgradeData)
    {
        SpellBase spellToUpgrade = spells.Find(sd => sd.spellData == upgradeData.spellData);
        spellToUpgrade.Upgrade(upgradeData);
    }
}
