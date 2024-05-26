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
        //box.OnMouseDownAsObservable().Subscribe(_ => { Debug.Log("���Cube"); }).AddTo(this);
        //box.UpdateAsObservable().Where(_=>
        //{
        //    bool mouseButtonDown = Input.GetMouseButtonDown(0);
        //    if(mouseButtonDown)
        //    {
        //        Debug.Log("����������");
        //        return true;
        //    }
        //    return false;
        //}).Delay(TimeSpan.FromSeconds(1)).Subscribe(_=>
        //{
        //    Debug.Log("�ӳ�һ�밴��������");
        //}).AddTo(this);

        var leftButtonDown = box.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(0));
        var rightButtonDown = box.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(1));
        leftButtonDown.Merge(rightButtonDown).Take(2).Subscribe(_ =>
        {
            Debug.Log("��갴��");
        }).AddTo(this);

        Observable.Return("hello").DelayFrame(5).Subscribe(str => { Debug.Log(str); }).AddTo(this);

        box.UpdateAsObservable().Do(_ =>
        {
            Debug.Log("�����֮ǰ");
        }).Where(_ => Input.GetMouseButtonDown(0)).Do(_ => { Debug.Log("�����"); })
        .Delay(TimeSpan.FromSeconds(1))
        .Do(_ => { Debug.Log("��ʱһ�������֮��"); })
        .Subscribe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
