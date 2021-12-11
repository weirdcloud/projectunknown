using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHeldSouls : MonoBehaviour
{
    [SerializeField]
    TMP_Text soulsText;
    [SerializeField]
    CurrencyCount currencyCount;

    void Start()
    {
        ChangeSoulsText(currencyCount.HeldSoulsAmount);
        currencyCount.changeHeldSoulsAmount.AddListener(ChangeSoulsText);
    }

    public void ChangeSoulsText(int amount)
    {
        string souls = "Held Souls: ";
        souls += amount.ToString();
        soulsText.text = souls;
    }
}
