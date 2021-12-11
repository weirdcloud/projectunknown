using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHealth : MonoBehaviour
{
    [SerializeField]
    TMP_Text hpText;
    public void ChangeHealthText(int amount)
    {
        string hp = "HP:";
        for (int i = 0; i < amount; i++)
        {
            hp += " *";
        }
        hpText.text = hp;
    }
}
