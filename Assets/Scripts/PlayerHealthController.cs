using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField]
    int hitPoints = 5;

    public void TakeDamage(int damage)
    {
        if (hitPoints - damage <= 0)
        {
            Die();
        }
        else
        {
            hitPoints -= damage;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
