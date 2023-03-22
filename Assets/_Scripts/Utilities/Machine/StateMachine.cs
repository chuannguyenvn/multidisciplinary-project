using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StateMachine<T> : Machine<T> where T : Enum
{
    public StateMachine(MonoBehaviour owner, T startingState) : base(owner)
    {
        _stateQueue.Enqueue(startingState);
    }

    public T CurrentState { get; private set; }
    private Queue<T> _stateQueue = new();
    private bool started = false;
    private bool isChangingState = false;

    public void StartMachine()
    {
        if (started) Debug.LogError("State machine is started multiple time.");
        else if (isChangingState) Debug.LogError("State machine is started while changing state.");
        else owner.StartCoroutine(StartMachine_CO());
    }

    public void EndMachine()
    {
        if (!started) Debug.LogError("State machine is ended before started.");
        else if (isChangingState) Debug.LogError("State machine is ended while changing state.");
        else
        {
            owner.StopCoroutine(StartMachine_CO());
            owner.StartCoroutine(EndMachine_CO());
        }
    }

    private IEnumerator StartMachine_CO()
    {
        yield return null;
        started = true;

        var startingState = _stateQueue.Dequeue();
        Debug.Log(owner.name + " is started with the state: " + startingState);
        yield return owner.StartCoroutine(RunQueueOfType(startingState, enterWorkUnits));

        while (true)
        {
            if (_stateQueue.Count > 0)
            {
                var newState = _stateQueue.Dequeue();
                yield return owner.StartCoroutine(ChangeState_CO(newState));
                CurrentState = newState;
            }
            else yield return null;
        }
    }

    private IEnumerator EndMachine_CO()
    {
        yield return null;
        started = false;

        Debug.Log(owner.name + " is ended with the state: " + CurrentState);
        yield return owner.StartCoroutine(RunQueueOfType(CurrentState, exitWorkUnits));
    }

    public void ChangeState(T newState)
    {
        Debug.Log(owner.name + " enters state: " + newState);
        if (!started) Debug.LogError("State machine changed state before starting.");
        // if (isChangingState)
        //     Debug.LogError("State machine changed state when changing to another state. Tried to change from " +
        //                    CurrentState + " to " + newState + ".");

        _stateQueue.Enqueue(newState);
    }

    private IEnumerator ChangeState_CO(T newState)
    {
        isChangingState = true;
        Debug.Log(owner.name + " executing OnExits.");
        yield return owner.StartCoroutine(RunQueueOfType(CurrentState, exitWorkUnits));
        Debug.Log(owner.name + " executing OnEntrys.");
        yield return owner.StartCoroutine(RunQueueOfType(newState, enterWorkUnits));
        isChangingState = false;

        CurrentState = newState;
    }

    public StateMachine<T> Configure(T configureState)
    {
        SettingState = configureState;
        return this;
    }

    public StateMachine<T> OnEntry(Action entryWork)
    {
        QueueAction(SettingState, entryWork, null);
        return this;
    }

    public StateMachine<T> OnEntry(Func<IEnumerator> entryWork)
    {
        QueueCoroutine(SettingState, entryWork, null);
        return this;
    }

    public StateMachine<T> OnEntry(Tween entryWork)
    {
        QueueTween(SettingState, entryWork, null);
        return this;
    }

    public StateMachine<T> OnExit(Action exitWork)
    {
        QueueAction(SettingState, null, exitWork);
        return this;
    }

    public StateMachine<T> OnExit(Func<IEnumerator> exitWork)
    {
        QueueCoroutine(SettingState, null, exitWork);
        return this;
    }

    public StateMachine<T> OnExit(Tween exitWork)
    {
        QueueTween(SettingState, null, exitWork);
        return this;
    }

    // public void Queue(T workType, Action enterWork, Action exitWork)
    // {
    //     QueueAction(workType, enterWork, exitWork);
    // }
    //
    // public void Queue(T workType, Func<IEnumerator> enterWork, Func<IEnumerator> exitWork)
    // {
    //     QueueCoroutine(workType, enterWork, exitWork);
    // }
    //
    // public void Queue(T workType, Tween enterWork, Tween exitWork)
    // {
    //     QueueTween(workType, enterWork, exitWork);
    // }

    // public void Queue<TChildQueue>(T workType, Machine<TChildQueue> enterMachine, Machine<TChildQueue> exitMachine)
    //     where TChildQueue : Enum
    // {
    //     QueueMachine(workType, enterMachine, exitMachine);
    // }
}