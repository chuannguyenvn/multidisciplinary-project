using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : PersistentSingleton<ApplicationManager>
{
    //public StateMachine<Define.ApplicationState> StateMachine;

    protected override void Awake()
    {
        base.Awake();
        //StateMachine = new StateMachine<Define.ApplicationState>(this, Define.ApplicationState.Login);
    }

    private void Start()
    {
        QueueWork();
    }

    public void QueueWork()
    {
        //StateMachine.StartMachine();
    }
}