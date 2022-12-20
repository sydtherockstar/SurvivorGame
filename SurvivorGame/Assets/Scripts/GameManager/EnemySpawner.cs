using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    Vector2 maxBound;
    Vector2 minBound;
    [SerializeField] LevelStageProgress levelSP;

    public void SpawnEnemy(GameObject enemyPrefab)
    {
        Vector3 spawnPosition = GenerateRandomSpawnPosition();
        GameObject enemyP = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, transform);
        enemyP.GetComponent<Enemy>().SetEnemyStats(levelSP);
    }
    /*void SetEnemyStats(GameObject enemyPrefab){
        enemyP = enemyPrefab.GetComponent<Enemy>();
        enemyP.hp = (int)(enemyP.hp * levelSP.StageProgress);
        enemyP.damage = (int)(enemyP.damage * levelSP.StageProgress);
        enemyP.experience = (int)(enemyP.experience * levelSP.StageProgress);
        enemyP.moveSpeed = (enemyP.moveSpeed * levelSP.StageProgress);
    }*/
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
