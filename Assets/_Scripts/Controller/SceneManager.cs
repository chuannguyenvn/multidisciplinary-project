using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : Singleton<SceneManager>
{
    private string _currentScene;
    
    public string GetCurrentScene()
    {
        return _currentScene;
    }
    public void ChangeScene(string scene)
    {
        _currentScene = scene;
        UnityEngine.SceneManagement.SceneManager.LoadScene("");
    }
}
