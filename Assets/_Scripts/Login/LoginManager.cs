using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : Singleton<LoginManager>
{
    [SerializeField] private TMP_InputField _accountField;
    [SerializeField] private TMP_InputField _passwordField;
    [SerializeField] private TMP_InputField _keyField;
    [SerializeField] private Button _loginButton;

    protected override void Awake()
    {
        base.Awake();
    }

    public void OnClickLogin()
    {
        //them ham check username va password o day
        SceneManager.Instance.ChangeScene(Define.SceneName.Main.ToString());
    }
    private void LoadPreviousSessionCredentials()
    {
        if (PlayerPrefs.HasKey("USERNAME"))
        {
            _accountField.text = PlayerPrefs.GetString("USERNAME");
            _passwordField.text = PlayerPrefs.GetString("PASSWORD");
            _keyField.text = PlayerPrefs.GetString("KEY");
        }
    }

    //private void ProceedLogin()
    //{
    //    AdafruitManager.Instance.TryConnect(_accountField.text, _keyField.text);
    //}

    private void LoginStatusReceivedHandler(bool success)
    {
        
    }

    private void SuccessfulLoginHandler()
    {
        PlayerPrefs.SetString("USERNAME", _accountField.text);
        PlayerPrefs.SetString("PASSWORD", _passwordField.text);
        PlayerPrefs.SetString("KEY", _keyField.text);
        
        gameObject.SetActive(false);
    }

    private void UnsuccessfulLoginHandler()
    {
        _accountField.text = "fuck you youre wrong dude";
    }
}