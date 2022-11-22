using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    public float timer;
    TimerUI timerUI;
    private void Awake() {
        timerUI = FindObjectOfType<TimerUI>();
    }
    private void Update() {
        timer += Time.deltaTime;
        timerUI.UpdateTime(timer);
    }
}
