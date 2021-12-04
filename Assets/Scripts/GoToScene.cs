using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName = "Game";
    public void ChangeScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
