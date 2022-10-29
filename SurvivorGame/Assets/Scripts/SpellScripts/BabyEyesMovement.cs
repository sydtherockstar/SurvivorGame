using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyEyesMovement : MonoBehaviour
{
    public float moveSpeed;
    public int spellDamage;
    public float lifeTime;
    GameObject player;
    private void Awake() {
        player = GameObject.Find("Shooter");
    }
    void Update()
    {
        transform.RotateAround(player.transform.position, new Vector3(0, 0, 1), moveSpeed * Time.deltaTime);
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        InterfaceDamagable e = other.GetComponent<InterfaceDamagable>();
            if(e != null){
                e.TakeDamage(spellDamage);
            }
    }
}
