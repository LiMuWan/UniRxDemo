using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.Events;
using System;
using NUnit.Framework.Constraints;

public class TestUniEvent : MonoBehaviour
{
    private UnityEvent unityEvent;

    private Subject<int> actionEvent = new Subject<int>();
    private Action<int> action;
    private Subject<Tuple<int, int>> tupleSubject = new Subject<Tuple<int, int>>();
    private event Action systemEvent;

    // Start is called before the first frame update
    void Start()
    {
        unityEvent.AsObservable().Subscribe(_ => { }).AddTo(this);
        actionEvent.Subscribe(_ => { }).AddTo(this);
        Observable.FromEvent(action => systemEvent+= action, action => systemEvent -= action).Subscribe(_ => { Debug.Log("ÄãÒª¶©ÔÄµÄÄÚÈÝ"); }).AddTo(this);
        tupleSubject.Subscribe(_ => 
        {
            Debug.Log($"{_.Item1} {_.Item2}");
        }).AddTo(this);

        action.Invoke(1);
        tupleSubject.OnNext(new Tuple<int, int> (1, 2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
