using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : PersistentSingleton<SceneManager>
{
    private string _currentScene;

    public void QueueWork()
    {
        ChangeScene(Define.SceneName.Main.ToString());
    }

    public string GetCurrentScene()
    {
        return _currentScene;
    }

    public void ChangeScene(string scene)
    {
        _currentScene = scene;
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}