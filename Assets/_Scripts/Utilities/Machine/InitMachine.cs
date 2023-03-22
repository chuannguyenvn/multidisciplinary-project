using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class InitMachine<T> : Machine<T> where T : Enum
{
    public bool Completed { get; private set; } = false;

    private bool isRunning = false;

    public InitMachine(MonoBehaviour owner) : base(owner)
    {
    }

    public void StartWorkQueue()
    {
        if (isRunning) Debug.LogError("InitMachine is started multiple time.");
        if (Completed) Debug.LogError("InitMachine is started before reverted.");
        owner.StartCoroutine(RunEnterWorkQueue_CO());
    }

    public void RevertWorkQueue()
    {
        if (isRunning) Debug.LogError("InitMachine is reverted when running.");
        if (!Completed) Debug.LogError("InitMachine is reverted before completed.");
        owner.StartCoroutine(RunExitWorkQueue_CO());
    }

    protected override IEnumerator RunEnterWorkQueue_CO()
    {
        isRunning = true;
        yield return base.RunEnterWorkQueue_CO();
        isRunning = false;
        Completed = true;
    }

    protected override IEnumerator RunExitWorkQueue_CO()
    {
        isRunning = true;
        yield return base.RunExitWorkQueue_CO();
        isRunning = false;
        Completed = false;
    }

    public void Queue(T workType, Action work)
    {
        QueueAction(workType, work, null);
    }

    public void Queue(T workType, Func<IEnumerator> work)
    {
        QueueCoroutine(workType, work, null);
    }

    public void Queue(T workType, Tween work)
    {
        QueueTween(workType, work, null);
    }

    // public void Queue<TChildQueue>(T workType, Machine<TChildQueue> machine) where TChildQueue : Enum
    // {
    //     QueueMachine(workType, machine, null);
    // }
}