using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UniRx.Triggers;

public class TestUniRX : MonoBehaviour
{
    [SerializeField]
    private GameObject box;

    private void Start()
    {
        //Observable.Timer(TimeSpan.FromSeconds(2f))
        //    .Subscribe(_ => { Debug.Log("2��"); })
        //    .AddTo(this);
        //Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0))
        //    .Subscribe(_ => { Debug.Log("�����갴��"); })
        //    .AddTo(this);
        //Observable.EveryUpdate().Sample(TimeSpan.FromSeconds(1)).
        //    Subscribe(_ => { Debug.Log("ÿ�����һ��"); })
        //    .AddTo(this);

        box.OnDisableAsObservable().Subscribe(_ => { Debug.Log("box����"); }).AddTo(this);
    }
}
