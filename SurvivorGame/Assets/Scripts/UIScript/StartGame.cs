using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{   
    [SerializeField] GameObject startPanel;

    public void StartGameScene(string stageToPlay){
        SceneManager.LoadScene("Essential", LoadSceneMode.Single);
        SceneManager.LoadScene(stageToPlay, LoadSceneMode.Additive);
    }
    public void StartGamePanel(){
        startPanel.SetActive(true);
    }
}
