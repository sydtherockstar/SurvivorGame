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
    List<int> randomNumberList;
    [SerializeField] List<UpgradeData> acquiredUpgrades;
    SpellManager spellManager;
    PassiveItems passiveItemManager;
    PlayerProperties pP;
    private void Awake() {
        spellManager = GetComponent<SpellManager>();
        passiveItemManager = GetComponent<PassiveItems>();
        pP = GetComponent<PlayerProperties>();
    }
    int TO_LEVEL_UP{
        get{
            return level * 1000;
        }
    }

    internal void AddUpgradeToListOfAvailableUpgrades(UpgradeData upgradesToAdd)
    {
        this.upgrades.Add(upgradesToAdd);
    }

    private void Start() {
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        experienceBar.SetLevelText(level);
    }
    public void AddExperience(int amount){
        
        experience += (amount + ((amount * pP.expUpRate)/100));
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
                spellManager.CheckLevelUp(upgradeData.spellData, upgradeData);
                break;
            case UpgradeType.PassiveUpgrade:
                passiveItemManager.CheckPassiveItemUpgrade(upgradeData.passiveItem, upgradeData);
                passiveItemManager.Upgrade(upgradeData.passiveUpgradeStats);
                break;
            case UpgradeType.SpellUnlock:
                spellManager.AddSpell(upgradeData.spellData);
                break;
            case UpgradeType.PassiveUnlock:
                passiveItemManager.Equip(upgradeData.passiveItem);
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
        if(randomNumberList == null){ randomNumberList = new List<int>(); }
            randomNumberList.Clear();
            randomNumberList.AddRange(GetRandomList(count));
        for(int i = 0; i < count; i++){
            upgradeDatas.Add(upgrades[randomNumberList[i]]);
        }  
        return upgradeDatas;
    }
    public List<int> GetRandomList(int maxNumber){
        List<int> randomNumberList = new List<int>();
        for(int i = 0; i < maxNumber; i++){
            int numToAdd = UnityEngine.Random.Range(0,maxNumber);
                while(randomNumberList.Contains(numToAdd)){
                numToAdd = UnityEngine.Random.Range(0,maxNumber);
                } randomNumberList.Add(numToAdd);
        }return randomNumberList;
    }
}
