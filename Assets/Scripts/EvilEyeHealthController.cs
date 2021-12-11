using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilEyeHealthController : MonoBehaviour, IHealthController
{
    [SerializeField]
    CurrencyCount currencyCount;

    [SerializeField]
    int hitPoints = 2;

    public void TakeDamage(int damage)
    {
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
