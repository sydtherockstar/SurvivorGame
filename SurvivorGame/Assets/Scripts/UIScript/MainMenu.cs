using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    PauseManager pM;
    private void Awake() {
        pM = GetComponent<PauseManager>();
    }
    void OnPause(InputValue value){
        if(value.isPressed){
            if(pausePanel.activeInHierarchy == false){
                OpenMenu();
            }else{
                CloseMenu();
            }
        }
    }
    public void OpenMenu(){
        pausePanel.SetActive(true);
        pM.PauseGame();
    }
    public void CloseMenu(){
        pausePanel.SetActive(false);
        pM.UnPauseGame();
    }

}
