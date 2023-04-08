using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : PersistentSingleton<SceneManager>
{
    private string _currentScene;
    protected override void Awake()
    {
        base.Awake();
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