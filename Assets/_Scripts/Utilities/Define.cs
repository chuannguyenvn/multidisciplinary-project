using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define : MonoBehaviour
{
    public enum SceneName
    {
        Login = 0,
        Main = 1,
    }
    public enum ApplicationState
    {
        Login,
        Main,
    }

    public enum LoginState
    {
        Waiting,
        Proceeding,
        Failed,
        Success,
    }
}
