using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void QuitGame(){
        Debug.Log("Quitting Game! ");
        Application.Quit();
    }
}
