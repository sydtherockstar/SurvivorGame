using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour, InterfacePickup
{
    [SerializeField] int coinAmount;

    public void OnPickUp(PlayerProperties playerProperties)
    {
        playerProperties.coins.Add(coinAmount);
    }
}
