using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : PersistentSingleton<ApplicationManager>, IMachineUser
{
    public StateMachine<ApplicationState> StateMachine;

    protected override void Awake()
    {
        base.Awake();
        StateMachine = new StateMachine<ApplicationState>(this, ApplicationState.Login);
    }

    private void Start()
    {
        QueueWork();
    }

    public void QueueWork()
    {
        StateMachine.StartMachine();
    }
}