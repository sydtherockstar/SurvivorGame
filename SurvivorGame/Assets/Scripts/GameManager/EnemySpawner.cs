using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    Vector2 maxBound;
    Vector2 minBound;

    public void SpawnEnemy(GameObject enemyPrefab)
    {
        Vector3 spawnPosition = GenerateRandomSpawnPosition();
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, transform);
    }
    private Vector3 GenerateRandomSpawnPosition(){
        minBound = Camera.main.ViewportToWorldPoint(new Vector3(-0.1f,-0.1f));
        maxBound = Camera.main.ViewportToWorldPoint(new Vector2(1.1f,1.1f));;
        Vector3 randomPosition = new Vector3();
        int r = UnityEngine.Random.Range(1,5);
        switch(r){
        case 1:
        randomPosition.x = UnityEngine.Random.Range(minBound.x, maxBound.x);
        randomPosition.y = maxBound.y;
        break;
        case 2:
        randomPosition.x = UnityEngine.Random.Range(minBound.x, maxBound.x);
        randomPosition.y = minBound.y;
        break;
        case 3:
        randomPosition.y = UnityEngine.Random.Range(minBound.y, maxBound.y);
        randomPosition.x = maxBound.x;
        break;
        case 4:
        randomPosition.y = UnityEngine.Random.Range(minBound.y, maxBound.y);
        randomPosition.x = minBound.x;
        break;
        default:
        break;
        }
        randomPosition.z = 0;
            return randomPosition;
    }
}
