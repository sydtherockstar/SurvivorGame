using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] DataContainerSO coinsData;
    [SerializeField] TMPro.TextMeshProUGUI coinsText;
    public void Add(int count){
        coinsData.coins += count;
        coinsText.text = coinsData.coins.ToString();
    }
}
