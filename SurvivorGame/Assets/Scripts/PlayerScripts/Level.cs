using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int level = 1;
    int experience = 0;
    [SerializeField] ExperienceBar experienceBar;
    [SerializeField] UpgradePanelManager upgradePanel;
    [SerializeField] List<UpgradeData> upgrades;
    List<UpgradeData> selectedUpgrades;
    [SerializeField] List<UpgradeData> acquiredUpgrades;
    SpellManager spellManager;
    private void Awake() {
        spellManager = GetComponent<SpellManager>();
    }
    int TO_LEVEL_UP{
        get{
            return level * 1000;
        }
    }

    internal void AddUpgradeToListOfAvailableUpgrades(List<UpgradeData> upgradesToAdd)
    {
        this.upgrades.AddRange(upgradesToAdd);
    }

    private void Start() {
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        experienceBar.SetLevelText(level);
    }
    public void AddExperience(int amount){
        experience += amount;
        CheckLevelUp();
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }

    public void Upgrade(int selectedUpgradeID)
    {
        UpgradeData upgradeData = selectedUpgrades[selectedUpgradeID]; 
        if(acquiredUpgrades == null){ acquiredUpgrades = new List<UpgradeData>(); }
        switch(upgradeData.upgradeType){
            case UpgradeType.SpellUpgrade:
                spellManager.UpgradeSpell(upgradeData);
                break;
            case UpgradeType.PassiveUpgrade:
                break;
            case UpgradeType.SpellUnlock:
                spellManager.AddSpell(upgradeData.spellData);
                break;
            case UpgradeType.PassiveUnlock:
                break;
        }
        acquiredUpgrades.Add(upgradeData);
        upgrades.Remove(upgradeData);
    }

    private void CheckLevelUp()
    {
        if(experience >= TO_LEVEL_UP)
        {
            LevelUp();
        }
    }
    void LevelUp()
    {
        if(selectedUpgrades == null){ selectedUpgrades = new List<UpgradeData>(); }
        selectedUpgrades.Clear();
        selectedUpgrades.AddRange(GetUpgrades(4));
        upgradePanel.OpenPanel(selectedUpgrades);
        experience -= TO_LEVEL_UP;
        level += 1;
        experienceBar.SetLevelText(level);
    }
    public List<UpgradeData> GetUpgrades(int count){
        List<UpgradeData> upgradeDatas = new List<UpgradeData>();
        if(count > upgrades.Count){
            count = upgrades.Count;
        }
        for(int i = 0; i < count; i++){
            upgradeDatas.Add(upgrades[UnityEngine.Random.Range(0, upgrades.Count)]);
        }  
        return upgradeDatas;
    }
}
