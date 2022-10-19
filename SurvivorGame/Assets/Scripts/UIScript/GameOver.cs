using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public void YouDied(){
        Debug.Log("Game Over");
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
