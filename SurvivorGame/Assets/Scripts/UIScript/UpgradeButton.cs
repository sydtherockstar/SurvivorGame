using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TMP_Text description;
    [SerializeField] TMP_Text levelIndex;
    public void Set(UpgradeData upgradeData){
        icon.sprite = upgradeData.icon;
        description.text = upgradeData.description;
        levelIndex.text = upgradeData.name;
    }

    internal void Clean()
    {
        icon.sprite = null;
        description.text = null;
    }
}
