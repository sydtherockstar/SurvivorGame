using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
{
    [SerializeField] GameObject upgradePanel;
    PauseManager pM;
    [SerializeField] List<UpgradeButton> upgradeButtons;
    private void Awake() {
        pM = GetComponent<PauseManager>();
    }
    private void Start() {
        HideButton();
    }
    public void OpenPanel(List<UpgradeData> upgradeDatas)
    {
        Clean();
        upgradePanel.SetActive(true);
        pM.PauseGame();
        
        for(int i = 0; i <upgradeDatas.Count; i++){
            upgradeButtons[i].gameObject.SetActive(true);
            upgradeButtons[i].Set(upgradeDatas[i]);
        }
    }
    public void Clean(){
        for(int i = 0; i <upgradeButtons.Count; i++){
            upgradeButtons[i].Clean();
        }
    }
    public void Upgrade(int pressedButton){
        GameManager.instance.playerTransform.GetComponent<Level>().Upgrade(pressedButton);
        ClosePanel();
    }
    public void ClosePanel()
    {
        HideButton();
        upgradePanel.SetActive(false);
        pM.UnPauseGame();
    }

    private void HideButton()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(false);
        }
    }
}
