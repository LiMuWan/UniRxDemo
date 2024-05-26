using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;


public class Temp
{
    public int index;
    public string str;
}

public class TestMessage : MonoBehaviour
{
    [SerializeField]
    private GameObject box;
    // Start is called before the first frame update
    void Start()
    {
        MessageBroker.Default.Receive<Temp>().SubscribeOnMainThread().Subscribe(_ =>
        {
            Debug.Log($"index = {_.index} str = {_.str}");
        }).AddTo(this);

        box.OnMouseDownAsObservable().Subscribe(_ => { MessageBroker.Default.Publish(new Temp() { index = 1 ,str = "rand"}); }).AddTo(this);
    }

}
