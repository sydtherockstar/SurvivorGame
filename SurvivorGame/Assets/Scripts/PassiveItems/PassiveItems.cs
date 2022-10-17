using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItems : MonoBehaviour
{
    [SerializeField] List<Item> items;
    PassiveItemStats passiveItemStats;
    PlayerProperties pP;
    private void Awake() {
        pP = GetComponent<PlayerProperties>();
    }
    public void Equip(Item itemEquip){
        if(items == null){
            items = new List<Item>();
        }
        items.Add(itemEquip);
        itemEquip.passiveItemStats.Equip(pP);
        Level level = GetComponent<Level>();
        if(level != null){
            level.AddUpgradeToListOfAvailableUpgrades(itemEquip.passiveUpgrades[0]);
        }
    }
    public void CheckPassiveItemUpgrade(Item passiveItemToCheck, UpgradeData upgradeData){
        int i = passiveItemToCheck.passiveUpgrades.IndexOf(upgradeData);
        Level level = GetComponent<Level>();
        if(level != null){
            if(upgradeData == passiveItemToCheck.passiveUpgrades[i]){
                if(i <= (passiveItemToCheck.passiveUpgrades.Count - 2)){
                    level.AddUpgradeToListOfAvailableUpgrades(passiveItemToCheck.passiveUpgrades[i + 1]);
                }else { return; }
            }
        }
    }
    public void Upgrade(PassiveItemStats passiveUpgradeData){
        passiveUpgradeData.Equip(pP);
    }
    public void UnEquip(Item itemUnEquip){

    }
}
