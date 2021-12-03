using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITutorialOkButton : MonoBehaviour
{
    [SerializeField]
    ScriptableBool isTutorialFinished;
    [SerializeField]
    GameObject[] tutorial;
    public void OnOkClick()
    {
        isTutorialFinished.isTrue = true;
        foreach (GameObject element in tutorial)
            element.SetActive(false);
    }
}
