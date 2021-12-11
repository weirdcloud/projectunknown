using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileController : MonoBehaviour
{
    [SerializeField]
    int damage = 1;

    public int Damage
    {
        get => damage;
        set => damage = value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHealthController health = collision.GetComponent<IHealthController>();
        if (health != null)
        {
            health.TakeDamage(Damage);
        }
        Destroy(gameObject);
    }
}
