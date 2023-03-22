using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public abstract class Machine<T> where T : Enum
{
    protected readonly Dictionary<T, List<WorkUnit>> enterWorkUnits;
    protected readonly Dictionary<T, List<WorkUnit>> exitWorkUnits;

    protected MonoBehaviour owner;
    protected T SettingState;

    public Machine(MonoBehaviour owner)
    {
        enterWorkUnits = new();
        exitWorkUnits = new();

        foreach (T value in Enum.GetValues(typeof(T)))
        {
            enterWorkUnits[value] = new();
            exitWorkUnits[value] = new();
        }

        this.owner = owner;
    }

    protected abstract class WorkUnit
    {
        public T WorkType { get; }

        public WorkUnit(T workType)
        {
            WorkType = workType;
        }
    }

    protected class SynchronousWorkUnit : WorkUnit
    {
        public Action Work { get; }

        public SynchronousWorkUnit(T workType, Action work) : base(workType)
        {
            Work = work;
        }
    }

    protected class AsynchronousWorkUnit : WorkUnit
    {
        public Func<IEnumerator> Work { get; }

        public AsynchronousWorkUnit(T workType, Func<IEnumerator> work) : base(workType)
        {
            Work = work;
        }
    }

    protected class TweenWorkUnit : WorkUnit
    {
        public Tween Work { get; }

        public TweenWorkUnit(T workType, Tween work) : base(workType)
        {
            Work = work;
        }
    }

    private void Queue(T workType, WorkUnit enterWorkUnit, WorkUnit exitWorkUnit)
    {
        if (enterWorkUnit != null) enterWorkUnits[workType].Add(enterWorkUnit);
        if (exitWorkUnit != null) exitWorkUnits[workType].Add(exitWorkUnit);
    }

    protected void QueueAction(T workType, Action enterWork, Action exitWork)
    {
        Queue(workType,
            enterWork != null ? new SynchronousWorkUnit(workType, enterWork) : null,
            exitWork != null ? new SynchronousWorkUnit(workType, exitWork) : null);
    }

    protected void QueueCoroutine(T workType, Func<IEnumerator> enterWork, Func<IEnumerator> exitWork)
    {
        Queue(workType,
            enterWork != null ? new AsynchronousWorkUnit(workType, enterWork) : null,
            exitWork != null ? new AsynchronousWorkUnit(workType, exitWork) : null);
    }

    protected void QueueTween(T workType, Tween enterWork, Tween exitWork)
    {
        enterWork.Pause();
        exitWork.Pause();

        Queue(workType,
            enterWork != null ? new TweenWorkUnit(workType, enterWork) : null,
            exitWork != null ? new TweenWorkUnit(workType, exitWork) : null);
    }

    // protected void QueueMachine<TChildQueue>(T workType, Machine<TChildQueue> enterMachine,
    //     Machine<TChildQueue> exitMachine) where TChildQueue : Enum
    // {
    //     QueueCoroutine(workType,
    //         enterMachine != null ? enterMachine.RunWorkQueue_CO : null,
    //         exitMachine != null ? exitMachine.RunWorkQueue_CO : null);
    // }

    protected virtual IEnumerator RunEnterWorkQueue_CO()
    {
        yield return null;

        foreach (T value in Enum.GetValues(typeof(T)))
        {
            Debug.Log(owner.name + "'s machine running enter works of state: " + value);
            yield return owner.StartCoroutine(RunQueueOfType(value, enterWorkUnits));
        }
    }

    protected virtual IEnumerator RunExitWorkQueue_CO()
    {
        yield return null;

        foreach (T value in Enum.GetValues(typeof(T)))
        {
            Debug.Log(owner.name + "'s machine running exit works of state: " + value);
            yield return owner.StartCoroutine(RunQueueOfType(value, exitWorkUnits));
        }
    }

    protected virtual IEnumerator RunWorkQueue_CO()
    {
        yield return null;

        foreach (T value in Enum.GetValues(typeof(T)))
        {
            Debug.Log(owner.name + "'s machine running all works of state: " + value);
            yield return owner.StartCoroutine(RunQueueOfType(value, enterWorkUnits));
            yield return owner.StartCoroutine(RunQueueOfType(value, exitWorkUnits));
        }
    }

    protected IEnumerator RunQueueOfType(T workType, Dictionary<T, List<WorkUnit>> workQueue)
    {
        List<Coroutine> coroutines = new();
        Sequence mainSequence = DOTween.Sequence().Pause();
        foreach (var workUnit in workQueue[workType])
        {
            switch (workUnit)
            {
                case SynchronousWorkUnit synchronousWorkUnit:
                    synchronousWorkUnit.Work.Invoke();
                    break;
                case AsynchronousWorkUnit asynchronousWorkUnit:
                    var coroutine = owner.StartCoroutine(asynchronousWorkUnit.Work.Invoke());
                    coroutines.Add(coroutine);
                    break;
                case TweenWorkUnit tweenWorkUnit:
                    mainSequence.Insert(0f, tweenWorkUnit.Work);
                    break;
            }
        }

        // Bug: Is this really parallel?
        foreach (var coroutine in coroutines)
        {
            yield return coroutine;
        }

        yield return mainSequence.Play().AsyncWaitForCompletion();
    }
}

public interface IMachineUser
{
    /// <summary>
    /// Add all works in the body and call the method in Start().
    /// </summary>
    public void QueueWork();
}