using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPowerups : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;
    [SerializeField]
    PowerUps activePowerUps;

    private void Start()
    {
        UpdatePowerUpText();
    }
    public void UpdatePowerUpText()
    {
        string powerups = "";
        if (activePowerUps.doubleDamage)
            powerups += "Double Damage\n";
        if (activePowerUps.tripleJump)
            powerups += "Triple Jump\n";
        if (activePowerUps.quickRecharge)
            powerups += "Quick Recharge\n";

        text.text = powerups;
    }
}
