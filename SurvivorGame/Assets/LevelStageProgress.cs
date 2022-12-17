using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStageProgress : MonoBehaviour
{
    LevelTimer levelTimer;
    [SerializeField] float timeRate;
    [SerializeField] float perTime;
    private void Awake() {
        levelTimer = GetComponent<LevelTimer>();
    }
    public float StageProgress{
        get{
            return 1f + levelTimer.timer / timeRate * perTime;
        }
    }
}
