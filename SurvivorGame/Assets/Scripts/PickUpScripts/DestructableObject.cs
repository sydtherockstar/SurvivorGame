using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour, InterfaceDamagable
{
    public void TakeDamage(int damage)
    {
        Destroy(gameObject);
    }
}
