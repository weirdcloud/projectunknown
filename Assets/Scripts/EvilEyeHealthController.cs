using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EvilEyeHealthController : MonoBehaviour, IHealthController
{
    [SerializeField]
    CurrencyCount currencyCount;

    [SerializeField]
    int hitPoints = 2;

    public UnityEvent damaged;

    public void TakeDamage(int damage)
    {
        damaged.Invoke();
        if (hitPoints - 1 <= 0)
        {
            Die();
        } 
        else
        {
            hitPoints--;
        }
    }

    private void Die()
    {
        currencyCount.HeldSoulsAmount += 1;
        Destroy(gameObject);
    }
}
