using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenuPanel : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
     public void BackToPanel(){
        startPanel.SetActive(false);
    }
}
