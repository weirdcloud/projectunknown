using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPlayButton : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName = "Game";
    public void OnButtonPressed()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
