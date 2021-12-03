using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITutorial : MonoBehaviour
{
    [SerializeField]
    ScriptableBool isTutorialFinished;
    [SerializeField]
    GameObject[] tutorial;

    private void Awake()
    {
        if (isTutorialFinished.isTrue)
        {
            foreach (GameObject element in tutorial)
                element.SetActive(false);
        }
        else
        {
            foreach (GameObject element in tutorial)
                element.SetActive(true);
        }
    }

    
}
