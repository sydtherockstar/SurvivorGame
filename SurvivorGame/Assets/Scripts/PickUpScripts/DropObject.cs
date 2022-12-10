using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    [SerializeField] List<GameObject> droppingObject;
    [SerializeField] [Range(0f,1f)] float dropChance = 1f;
    bool isQuit = false; 

    private void OnApplicationQuit() {
        isQuit = true;
    }
    private void OnDestroy() {
        if(isQuit) { return; }
        if(Random.value < dropChance){
        GameObject dropObject = droppingObject[Random.Range(0, droppingObject.Count)];
        Instantiate(dropObject, transform.position, Quaternion.identity);
        }
    }
}
