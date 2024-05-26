using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class TestBoxOnClick : MonoBehaviour
{
    [SerializeField]
    private GameObject box;

    // Start is called before the first frame update
    void Start()
    {
        //box.OnMouseDownAsObservable().Subscribe(_ => { Debug.Log("点击Cube"); }).AddTo(this);
        //box.UpdateAsObservable().Where(_=>
        //{
        //    bool mouseButtonDown = Input.GetMouseButtonDown(0);
        //    if(mouseButtonDown)
        //    {
        //        Debug.Log("按下鼠标左键");
        //        return true;
        //    }
        //    return false;
        //}).Delay(TimeSpan.FromSeconds(1)).Subscribe(_=>
        //{
        //    Debug.Log("延迟一秒按下鼠标左键");
        //}).AddTo(this);

        var leftButtonDown = box.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(0));
        var rightButtonDown = box.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(1));
        leftButtonDown.Merge(rightButtonDown).Take(2).Subscribe(_ =>
        {
            Debug.Log("鼠标按下");
        }).AddTo(this);

        Observable.Return("hello").DelayFrame(5).Subscribe(str => { Debug.Log(str); }).AddTo(this);

        box.UpdateAsObservable().Do(_ =>
        {
            Debug.Log("鼠标点击之前");
        }).Where(_ => Input.GetMouseButtonDown(0)).Do(_ => { Debug.Log("鼠标点击"); })
        .Delay(TimeSpan.FromSeconds(1))
        .Do(_ => { Debug.Log("延时一秒鼠标点击之后"); })
        .Subscribe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
