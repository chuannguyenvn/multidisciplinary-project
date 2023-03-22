using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : PersistentSingleton<LoginManager>
{
    public StateMachine<LoginState> StateMachine;

    [SerializeField] private TMP_InputField _accountField;
    [SerializeField] private TMP_InputField _passwordField;
    [SerializeField] private TMP_InputField _keyField;
    [SerializeField] private Button _loginButton;

    protected override void Awake()
    {
        base.Awake();
        StateMachine = new StateMachine<LoginState>(this, LoginState.Waiting);
    }

    private void Start()
    {
        _loginButton.onClick.AddListener(ProceedLogin);
        AdafruitManager.Instance.LoginStatusReceived += LoginStatusReceivedHandler;

        LoadPreviousSessionCredentials();

        QueueWork();
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

    public void QueueWork()
    {
        StateMachine.Configure(LoginState.Proceeding).OnExit(ProceedLogin);
        StateMachine.Configure(LoginState.Success).OnEntry(SuccessfulLoginHandler);
        StateMachine.Configure(LoginState.Failed).OnEntry(UnsuccessfulLoginHandler);

        StateMachine.StartMachine();
    }

    private void ProceedLogin()
    {
        if (StateMachine.CurrentState == LoginState.Proceeding) return;

        AdafruitManager.Instance.TryConnect(_accountField.text, _keyField.text);
    }

    private void LoginStatusReceivedHandler(bool success)
    {
        if (success) StateMachine.ChangeState(LoginState.Success);
        else StateMachine.ChangeState(LoginState.Failed);
    }

    private void SuccessfulLoginHandler()
    {
        ApplicationManager.Instance.StateMachine.ChangeState(ApplicationState.ConnectingToAdafruit);
        PlayerPrefs.SetString("USERNAME", _accountField.text);
        PlayerPrefs.SetString("PASSWORD", _passwordField.text);
        PlayerPrefs.SetString("KEY", _keyField.text);
    }

    private void UnsuccessfulLoginHandler()
    {
        _accountField.text = "fuck you youre wrong dude";
    }
}

public enum LoginState
{
    Waiting,
    Proceeding,
    Failed,
    Success,
}