using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellBase : MonoBehaviour
{
    public SpellSO spellData;
    public SpellStats spellStats; 
    
    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public PlayerProperties pP;
    [HideInInspector]
    public PlayerMovement pM;
    float timer = 1f;
    
    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        pP = player.GetComponent<PlayerProperties>();
        pM = player.GetComponent<PlayerMovement>();
    }
    public void Update() {
        float duration = spellStats.timeToAttack - spellStats.duration;
        timer -= Time.deltaTime;
        if(timer < 0f){
            Attack();
            timer = spellStats.timeToAttack + pP.baseCooldown;
            timer = Mathf.Clamp(timer, 0.1f, timer);
        }
        if(timer < duration){
            Disable();
        }
    }
    public virtual void SetData(SpellSO sd){
        spellData = sd;
        spellStats = new SpellStats(sd.spellStats.damage, sd.spellStats.speed, sd.spellStats.timeToAttack, 
                                        sd.spellStats.duration, sd.spellStats.numberOfAttack, sd.spellStats.scale);
    }
    public abstract void Attack();
    public abstract void Disable();
    public void Upgrade(UpgradeData upgradeData){
        spellStats.Sum(upgradeData.spellUpgradeStats);
    }
}
