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
        StartCoroutine(ResourceManager.Instance.RequestLogin(_accountField.text, _passwordField.text));
    }
}