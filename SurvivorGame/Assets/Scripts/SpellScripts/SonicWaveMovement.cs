using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicWaveMovement : MonoBehaviour
{
public float moveSpeed;
    public int spellDamage;
    public float lifeTime;
    [SerializeField] int hitCount;
    GameObject player;
    PlayerMovement pM;
    Vector2 targetDirection;
    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        pM = player.GetComponent<PlayerMovement>();
    }
    private void Start() {
        //targetDirection = (player.GetComponent<Aim>().GetMousePosition() - (Vector2)transform.position).normalized;
        targetDirection = pM.GetPlayerMovement();
    }
    void Update()
    {
        transform.position += (Vector3)targetDirection * moveSpeed * Time.deltaTime;
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        InterfaceDamagable e = other.GetComponent<InterfaceDamagable>();
            if(e != null){
                DamagePopup.instance.PostMessage(spellDamage.ToString(), other.transform.position);
                e.TakeDamage(spellDamage);
                hitCount -= 1;
                if(hitCount == 0){
                    Destroy(gameObject);
                }
            }
    }
}
