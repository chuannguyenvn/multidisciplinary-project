using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define : MonoBehaviour
{
    public static string TOPIC_LIGHT = "light";
    public static string TOPIC_TEMPERATURE = "temperature";
    public static string TOPIC_MOISTURE = "moisture";
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
