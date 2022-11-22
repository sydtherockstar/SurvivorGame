using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStageManager : MonoBehaviour
{
    [SerializeField] LevelStageSO stageData;
    [SerializeField] EnemySpawner enemySpawner;
    LevelTimer stageTime;
    int eIndex;
    private void Awake() {
        stageTime = GetComponent<LevelTimer>();
    }
    private void Update() {
        if(eIndex >= stageData.stageEvents.Count) { return; }
        if(stageTime.timer > stageData.stageEvents[eIndex].time){
            Debug.Log(stageData.stageEvents[eIndex].message);
            for(int i = 0; i <= stageData.stageEvents[eIndex].enemyCount; i++){
                enemySpawner.SpawnEnemy();
            }
            eIndex += 1;
        }
    }
}
