using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    [SerializeField] int maxHp;
    [SerializeField] int currentHp;
    [SerializeField] Status hpBar;
    [HideInInspector] public Level level;
    [HideInInspector] public Coins coins;
    public int armor = 0;
    public float hpRegenerationRate = 1f;
    public float hpRegenerationTimer = 1f;
    private bool isDead;

    private void Awake() {
        level = GetComponent<Level>();
        coins = GetComponent<Coins>();
    }
    private void Start() {
        hpBar.SetState(currentHp, maxHp);
    }
    private void Update() {
        hpRegenerationTimer += Time.deltaTime * hpRegenerationRate;
        if(hpRegenerationTimer > 1){
            Heal(1);
            hpRegenerationTimer -= 1;
        }
    }
    public int GetMaxHp(){
        return maxHp;
    }
    public int GetCurrentHp(){
        return currentHp;
    }
    public void TakeDamage(int damage){
        if(isDead == true) { return; }
        ApplyArmor(ref damage);
        currentHp -= damage;
        if (currentHp <= 0)
        {
            isDead = true;
            GetComponent<GameOver>().GameOverFunc();
        }
        hpBar.SetState(currentHp, maxHp);
    }

    private void ApplyArmor(ref int damage)
    {
        damage -= armor;
        if (damage < 0){ damage = 0; }
    }

    public void Heal(int amount){
        if (currentHp <= 0) { return; }
        currentHp += amount;
        if (currentHp >= maxHp) { currentHp = maxHp; }
        hpBar.SetState(currentHp, maxHp);
    }
}
