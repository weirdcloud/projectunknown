using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILvlFinish : MonoBehaviour
{
    [SerializeField]
    GameObject[] uiElements;
    public void EnableUI()
    {
        foreach (GameObject element in uiElements)
        {
            element.SetActive(true);
        }
    }
}
