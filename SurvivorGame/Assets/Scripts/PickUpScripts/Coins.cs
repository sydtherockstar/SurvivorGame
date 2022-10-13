using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinAcquired;
    [SerializeField] TMPro.TextMeshProUGUI coinsText;
    public void Add(int count){
        coinAcquired += count;
        coinsText.text = coinAcquired.ToString();
    }
}
