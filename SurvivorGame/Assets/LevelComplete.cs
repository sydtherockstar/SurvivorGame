using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] float levelCompleteTimer;
    LevelTimer levelTimer;
    PauseManager pauseManager;
    LevelCompletePanel levelCompletePanel;
    private void Start() {
        levelTimer = GetComponent<LevelTimer>();
        pauseManager = FindObjectOfType<PauseManager>(); //bu awakede çalışmayabilir.
        levelCompletePanel = FindObjectOfType<LevelCompletePanel>(true);
    }
    private void Update() {
        if(levelTimer.timer > levelCompleteTimer){
            pauseManager.PauseGame();
            levelCompletePanel.gameObject.SetActive(true);
        }
    }
}
