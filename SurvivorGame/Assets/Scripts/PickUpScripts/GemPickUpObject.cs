using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickUpObject : MonoBehaviour, InterfacePickup
{
    [SerializeField] int expAmount;

    public void OnPickUp(PlayerProperties playerProperties)
    {
        playerProperties.level.AddExperience(expAmount);
    }
}
