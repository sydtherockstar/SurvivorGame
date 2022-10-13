using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadar : MonoBehaviour
{
    GameObject[] multipleEnemies;
    Transform closestEnemy;
    void Awake()
    {
        closestEnemy = null;
    }
    void Update()
    {
        closestEnemy = FindClosestEnemy();
    }
    Transform FindClosestEnemy()
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
        }
        return trans;
    }
    public Transform GetClosestEnemy()
    {
        return closestEnemy;
    }
}
