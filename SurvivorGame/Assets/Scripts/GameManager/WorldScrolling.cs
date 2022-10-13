using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScrolling : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    Vector2Int currentTilePosition = new Vector2Int(0,0);
    [SerializeField] Vector2Int playerTilePosition;
    Vector2Int onTileGridPosition;
    [SerializeField] float tileSize = 20f;
    GameObject[,] terrainTiles;
    [SerializeField] int terrainTileHorizantalCount;
    [SerializeField] int terrainTileVerticalCount;
    [SerializeField] int fieldOfVisionHeight = 3;
    [SerializeField] int fieldOfVisionWidht = 3;

    private void Awake() {
        terrainTiles = new GameObject[terrainTileHorizantalCount, 
                                        terrainTileVerticalCount];
    }
    private void Start() {
        UpdateTilesOnScreen();
        playerTransform = GameManager.instance.playerTransform;
    }
    private void Update() {
        playerTilePosition.x = (int)(playerTransform.position.x / tileSize);
        playerTilePosition.y = (int)(playerTransform.position.y / tileSize);

        playerTilePosition.x -= playerTransform.position.x < 0 ? 1 : 0;
        playerTilePosition.y -= playerTransform.position.y < 0 ? 1 : 0;

        if(currentTilePosition != playerTilePosition){
            currentTilePosition = playerTilePosition;
            onTileGridPosition.x = CalculatePositionOnAxis(onTileGridPosition.x, true);
            onTileGridPosition.y = CalculatePositionOnAxis(onTileGridPosition.y, false);
            UpdateTilesOnScreen();
        }
    }

    private void UpdateTilesOnScreen()
    {
        for(int pov_x = -(fieldOfVisionWidht/2); pov_x <= fieldOfVisionWidht/2; pov_x++)
        {
            for(int pov_y = -(fieldOfVisionHeight/2); pov_y <= fieldOfVisionHeight/2; pov_y++){
                int tileToUpdate_x = CalculatePositionOnAxis(playerTilePosition.x + pov_x, true);
                int tileToUpdate_y = CalculatePositionOnAxis(playerTilePosition.y + pov_y, false);
                GameObject tile = terrainTiles[tileToUpdate_x, tileToUpdate_y];
                tile.transform.position = CalculateTilePosition(
                    playerTilePosition.x + pov_x,
                    playerTilePosition.y + pov_y);
            }
        }
    }

    private Vector3 CalculateTilePosition(int x, int y)
    {
        return new Vector3(x * tileSize, y * tileSize, 0f);
    }

    private int CalculatePositionOnAxis(float currentValue, bool horizantal)
    {
        if(horizantal){
            if(currentValue >= 0){
                currentValue = currentValue % terrainTileHorizantalCount;
            }else{
                currentValue += 1;
                currentValue = terrainTileHorizantalCount -1 + currentValue % terrainTileHorizantalCount;
            }
        }else{
            if(currentValue >= 0){
                currentValue = currentValue % terrainTileVerticalCount;
            }else{
                currentValue +=1;
                currentValue = terrainTileVerticalCount -1 + currentValue % terrainTileVerticalCount;
            }
        }   
        return (int)currentValue;
    }

    internal void Add(GameObject tileGameObject, Vector2Int tilePosition)
    {
        terrainTiles[tilePosition.x, tilePosition.y] = tileGameObject;
    }
}
