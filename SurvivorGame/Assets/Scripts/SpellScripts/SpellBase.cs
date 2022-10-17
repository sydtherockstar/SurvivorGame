using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellBase : MonoBehaviour
{
    public SpellSO spellData;
    public SpellStats spellStats; 
    public PlayerProperties pP;
    GameObject player;
    private void Awake() {
        player = GameObject.Find("Player");
        pP = player.GetComponent<PlayerProperties>();
    }
    float timer;
    public void Update() {
        //float newTimer = 0f;
        timer -= Time.deltaTime;
        if(timer < 0f){
            Attack();
            timer = spellStats.timeToAttack + pP.baseCooldown;
            timer = Mathf.Clamp(timer, 0.1f, timer);
        }
    }
    public virtual void SetData(SpellSO sd){
        spellData = sd;
        spellStats = new SpellStats(sd.spellStats.damage, sd.spellStats.timeToAttack, sd.spellStats.numberOfAttack);
    }
    public abstract void Attack();
    public void Upgrade(UpgradeData upgradeData){
        spellStats.Sum(upgradeData.spellUpgradeStats);
    }
}
