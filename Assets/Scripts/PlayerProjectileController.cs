using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileController : MonoBehaviour
{
    [SerializeField]
    PowerUps activePowerUps;
    [SerializeField]
    int damage = 1;

    public int Damage 
    { 
        get
        {
            if (activePowerUps.doubleDamage)
                return damage * 2;
            else
                return damage;
        }
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
