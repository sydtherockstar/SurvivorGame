using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{   
    public string level;
    
    private void Start() {
        this.gameObject.SetActive(false);
    }
    public void LevelSelection(string levelString){ 
        level = levelString;
    }
    public void StartGameScene(){
        SceneManager.LoadScene("Essential", LoadSceneMode.Single);
        SceneManager.LoadScene(level, LoadSceneMode.Additive);
    }
}
