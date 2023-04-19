using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : Singleton<LoginManager>
{
    [SerializeField]
    private TMP_InputField _accountField;
    [SerializeField]
    private TMP_InputField _passwordField;
    [SerializeField]
    private Button _loginButton;

    protected override void Awake()
    {
        base.Awake();
    }

    public void OnClickLogin()
    {
        //var myCo = ResourceManager.Instance.RequestLogin(_accountField.text, _passwordField.text);
        ResourceManager.Instance.RequestLogin(_accountField.text, _passwordField.text);
        Debug.LogError("check login: " + ResourceManager.Instance.IsCorrect);
        //StartCoroutine(myCo);
        Debug.LogError("check login 2: " + ResourceManager.Instance.IsCorrect);
        //if (ResourceManager.Instance.IsCorrect)
        //    SceneManager.Instance.ChangeScene(Define.SceneName.Main.ToString(), null);
    }
}