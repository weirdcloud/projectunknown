using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthController : MonoBehaviour, IHealthController
{
    [SerializeField]
    int hitPoints = 5;

    public IntEvent changeHealth;
    public UnityEvent playerDeath;

    public void TakeDamage(int damage)
    {
        if (hitPoints - damage <= 0)
        {
            changeHealth.Invoke(0);
            Die();
        }
        else
        {
            hitPoints -= damage;
            changeHealth.Invoke(hitPoints);
        }
    }

    private void Die()
    {
        playerDeath.Invoke();
        Destroy(gameObject);
    }
}
