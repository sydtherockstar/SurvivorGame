using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string itemName;
    public int armor;
    public void Equip(PlayerProperties pP){
         pP.armor += armor;
    }
    public void UnEquip(PlayerProperties pP){
        pP.armor -= armor;
    }
}
