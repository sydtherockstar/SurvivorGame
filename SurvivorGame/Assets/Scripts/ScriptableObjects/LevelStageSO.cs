using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StageEvent
{
    public float time;
    public string message;
    public GameObject enemyToSpawn;
    public int enemyCount;

}
[CreateAssetMenu]
public class LevelStageSO : ScriptableObject
{
    public List<StageEvent> stageEvents;
}
