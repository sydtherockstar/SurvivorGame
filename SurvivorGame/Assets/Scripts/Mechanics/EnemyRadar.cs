using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadar : MonoBehaviour
{
    GameObject[] multipleEnemies;
    public Transform FindClosestEnemy()
    {
        multipleEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        Transform trans = null;

        foreach(GameObject go in multipleEnemies)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, go.transform.position);
            if(currentDistance < closestDistance)
            {   
                closestDistance = currentDistance;
                trans = go.transform;
            }
            if(trans == null){
                trans = go.transform;
            }
        }
        return trans;
    }
    public Transform FindSecondClosestEnemy()
    {
        multipleEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        float secondClosestDistance = closestDistance;
        Transform trans = null;
        foreach(GameObject go in multipleEnemies)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, go.transform.position);
            if(currentDistance < closestDistance){  
                secondClosestDistance = closestDistance; 
                closestDistance = currentDistance;
            }else if (currentDistance < secondClosestDistance){
                secondClosestDistance = currentDistance;
                trans = go.transform;
            }
            if(trans == null){
                trans = go.transform;
            }
        }
        return trans;
    }
}
