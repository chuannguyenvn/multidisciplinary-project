using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : Singleton<LoginManager>
{
    public StateMachine<Define.LoginState> StateMachine;

    [SerializeField] private TMP_InputField _accountField;
    [SerializeField] private TMP_InputField _passwordField;
    [SerializeField] private TMP_InputField _keyField;
    [SerializeField] private Button _loginButton;

    protected override void Awake()
    {
        base.Awake();
        StateMachine = new StateMachine<Define.LoginState>(this, Define.LoginState.Waiting);
    }

    private void Start()
    {
        //_loginButton.onClick.AddListener(ProceedLogin);
        //AdafruitManager.Instance.LoginStatusReceived += LoginStatusReceivedHandler;

        //LoadPreviousSessionCredentials();

        //QueueWork();
    }
    public void OnClickLogin()
    {
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

    public void QueueWork()
    {
        StateMachine.Configure(Define.LoginState.Proceeding).OnExit(ProceedLogin);
        StateMachine.Configure(Define.LoginState.Success).OnEntry(SuccessfulLoginHandler);
        StateMachine.Configure(Define.LoginState.Failed).OnEntry(UnsuccessfulLoginHandler);

        ApplicationManager.Instance.StateMachine.Configure(Define.ApplicationState.Login).OnEntry(StateMachine.StartMachine);
    }

    private void ProceedLogin()
    {
        if (StateMachine.CurrentState == Define.LoginState.Proceeding) return;

        AdafruitManager.Instance.TryConnect(_accountField.text, _keyField.text);
    }

    private void LoginStatusReceivedHandler(bool success)
    {
        if (success) StateMachine.ChangeState(Define.LoginState.Success);
        else StateMachine.ChangeState(Define.LoginState.Failed);
    }

    private void SuccessfulLoginHandler()
    {
        PlayerPrefs.SetString("USERNAME", _accountField.text);
        PlayerPrefs.SetString("PASSWORD", _passwordField.text);
        PlayerPrefs.SetString("KEY", _keyField.text);
        
        ApplicationManager.Instance.StateMachine.ChangeState(Define.ApplicationState.Main);
        gameObject.SetActive(false);
    }

    private void UnsuccessfulLoginHandler()
    {
        _accountField.text = "fuck you youre wrong dude";
    }
}