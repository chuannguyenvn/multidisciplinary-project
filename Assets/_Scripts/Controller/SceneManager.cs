using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : PersistentSingleton<SceneManager>, IMachineUser
{
    private string _currentScene;

    private void Start()
    {
        QueueWork();
    }

    public void QueueWork()
    {
        ApplicationManager.Instance.StateMachine.Configure(ApplicationState.ConnectingToAdafruit)
            .OnExit(() => ChangeScene("Main"));
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