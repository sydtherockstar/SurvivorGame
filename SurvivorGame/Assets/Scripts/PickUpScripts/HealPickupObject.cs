using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickupObject : MonoBehaviour, InterfacePickup
{
    [SerializeField] int healAmount;
    public void OnPickUp(PlayerProperties playerProperties)
    {
        playerProperties.Heal(healAmount);
    }
}
