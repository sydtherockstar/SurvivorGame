using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightFollow : MonoBehaviour
{

    [SerializeField] GameObject player;
    
  
    void Update()
    {
        transform.position = player.transform.position;
    }
}
