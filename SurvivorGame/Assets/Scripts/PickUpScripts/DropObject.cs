using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    [SerializeField] GameObject droppingObject;
    [SerializeField] [Range(0f,1f)] float dropChance = 1f;
    private void OnDestroy() {
        if(Random.value < dropChance){
        Instantiate(droppingObject, transform.position, Quaternion.identity);
        }
    }
}
