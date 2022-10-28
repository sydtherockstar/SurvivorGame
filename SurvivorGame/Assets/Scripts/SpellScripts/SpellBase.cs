using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellBase : MonoBehaviour
{
    public SpellSO spellData;
    public SpellStats spellStats; 
    public PlayerProperties pP;
    public GameObject player;
    private void Awake() {
        player = GameObject.Find("Player");
        pP = player.GetComponent<PlayerProperties>();
    }
    float timer = 0.1f;
    public float disableTimer = 0.2f; // belki spellere bu timer eklenebilir DURATION adı altında.
    public void Update() {
        timer -= Time.deltaTime;
        if(timer < 0f){
            Attack();
            timer = spellStats.timeToAttack + pP.baseCooldown;
            timer = Mathf.Clamp(timer, 0.1f, timer);
        }
        if(timer < disableTimer){
            Disable();
        }
    }
    public virtual void SetData(SpellSO sd){
        spellData = sd;
        spellStats = new SpellStats(sd.spellStats.damage, sd.spellStats.timeToAttack, sd.spellStats.numberOfAttack, sd.spellStats.scale);
    }
    public abstract void Attack();
    public abstract void Disable();
    public void Upgrade(UpgradeData upgradeData){
        spellStats.Sum(upgradeData.spellUpgradeStats);
    }
}
