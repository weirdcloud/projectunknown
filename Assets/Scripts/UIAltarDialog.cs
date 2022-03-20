using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIAltarDialog : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;
    public void Awake()
    {
        ClearAltarResponse();
    }
    public void SetAltarResponse(bool blessed)
    {
        if (blessed)
            text.text = "Altar says: My blessing is with you, little warrior.";
        else
            text.text = "Altar says: \nI need 10 souls to give you power, little warrior.";
    }

    public void ClearAltarResponse()
    {
        text.text = "";
    }
}
