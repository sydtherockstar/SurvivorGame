using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItems : MonoBehaviour
{
    [SerializeField] List<Item> items;
    PlayerProperties pP;
    [SerializeField] Item armorTest;
    private void Awake() {
        pP = GetComponent<PlayerProperties>();
    }
    private void Start() {
        Equip(armorTest);
    }
    public void Equip(Item itemEquip){
        if(items == null){
            items = new List<Item>();
        }
        items.Add(itemEquip);
        itemEquip.Equip(pP);
    }
    public void UnEquip(Item itemUnEquip){

    }
}
