using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIQuitButton : MonoBehaviour
{
    public void OnButtonPressed()
    {
        Application.Quit();
    }
}
