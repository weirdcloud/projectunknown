using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarBlessing : MonoBehaviour
{
    [SerializeField]
    PowerUps activePowerUps;
    [SerializeField]
    CurrencyCount currencyCount;
    [SerializeField]
    int price = 10;

    public void buyPowerUp()
    {
        if (currencyCount.SoulsAmount >= price)
        {
            currencyCount.SoulsAmount -= price;
            enableRandomPowerUp();
        }
    }

    void enableRandomPowerUp()
    {
        int random = Random.Range(0, 2);
        switch(random)
        {
            case 1:
                activePowerUps.doubleDamage = true;
                break;
            case 2:
                activePowerUps.quickRecharge = true;
                break;
            case 3:
                activePowerUps.tripleJump = true;
                break;
        }
    }
}
