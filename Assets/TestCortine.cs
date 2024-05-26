using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TestCortine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IE().ToObservable().Catch<Unit,Exception>(exception =>
        {
            Debug.LogError($"异常:{exception}");
            return Observable.ReturnUnit();
        }).DoOnCompleted(() =>
        {
            Debug.Log("执行完成");
        }).Subscribe().AddTo(this);
        //Obs().DoOnCompleted(() => { Debug.Log("Obs执行完成"); }).Subscribe().AddTo(this);
        //var ObsIE = Obs().DoOnCompleted(() => { Debug.Log("Obs执行完成1"); }).ToYieldInstruction();
        //StartCoroutine(ObsIE);
    }

    IEnumerator IE(Action onComple = null)
    {
        int index = 0;
        Debug.Log("1111");
        yield return null;
        Debug.Log("2222");
        int[] array = new int[0];
        index = array[0];
        Debug.Log("-------");
        onComple?.Invoke();
    }

    IObservable<Unit> Obs()
    {
        int index = 0;
        IObservable<Unit> returnUnit = Observable.ReturnUnit();
        returnUnit = returnUnit.Do(unit => Debug.Log("11111")).DelayFrame(0)
            .Do(unit => Debug.Log("22222"))
            .Do(unit =>
            {
                int[] array = new int[0];
                index = array[1];
                Debug.Log($"--------");
            }).Catch<Unit, Exception>(_ =>
            {
                index = -1;
                Debug.LogError($"index = {index}");
                return Observable.ReturnUnit();
            });
        return returnUnit;
    }
}
