using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UnityEngine.UI;
using UniRx.Triggers;
public class Intro : MonoBehaviour
{
    [SerializeField]
    private Button button;
    [SerializeField]
    private Image image;
    [SerializeField]
    private Toggle toggle;
    [SerializeField]
    private Text text; 
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private InputField input;
    private IntReactiveProperty age = new IntReactiveProperty();
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate().Subscribe(_ => 
        {
           if(Input.GetMouseButtonDown(0))
            {
                Debug.Log("监听鼠标左键");
            }
        }).AddTo(this);
        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).Subscribe(_ =>
        {
            Debug.Log("监听鼠标左键");
        });
        Observable.EveryUpdate().//事件源，事件发布者
            First() //处理、组织、整理
            .Subscribe(_ => { Debug.Log("只处理第一次鼠标按下"); }) //订阅者
            .AddTo(this);//生命周期绑定
        Observable.EveryUpdate().Subscribe(_ =>
        {
            if(Input.GetMouseButtonUp(0))
            Debug.Log("监听鼠标右键");
        }).AddTo(this);
        Observable.Timer(TimeSpan.FromSeconds(1)).Subscribe(_ =>
        {
            Debug.Log("do something");
        });

        //UIExample
        button.OnClickAsObservable().Subscribe(_=>{ Debug.Log("OnClick"); }).AddTo(this);
        toggle.OnValueChangedAsObservable().Subscribe(_ => { Debug.Log($"OnValue = {_}"); }).AddTo(this);
        toggle.OnValueChangedAsObservable().SubscribeToInteractable(button).AddTo(this);
        image.OnBeginDragAsObservable().Subscribe(_ => { Debug.Log("BeginDrag"); }).AddTo(this);
        image.OnDragAsObservable().Subscribe(_ => { Debug.Log("Drag"); }).AddTo(this);
        image.OnEndDragAsObservable().Subscribe(_ => { Debug.Log("EndDrag"); }).AddTo(this);
        slider.OnValueChangedAsObservable().SubscribeToText(text, x => Math.Round(x,2).ToString());
        input.OnValueChangedAsObservable().Where(x=>x!=null).SubscribeToText(text);
        age.Subscribe(_ =>
        {
            Debug.Log($"age = {_}");
        });

        age.Value = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
