using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIAltarSouls : MonoBehaviour
{
    [SerializeField]
    TMP_Text soulsText;
    [SerializeField]
    CurrencyCount currencyCount;

    void Start()
    {
        ChangeSoulsText(currencyCount.SoulsAmount);
        currencyCount.changeSoulsAmount.AddListener(ChangeSoulsText);
    }

    public void ChangeSoulsText(int amount)
    {
        string souls = "Altar Souls: ";
        souls += amount.ToString();
        soulsText.text = souls;
    }
}
