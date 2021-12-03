using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHealthController health = collision.GetComponent<IHealthController>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
