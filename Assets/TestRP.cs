using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using UnityEngine.Serialization;

public class TestRP : MonoBehaviour
{
    [FormerlySerializedAs("box2")]
    public GameObject box;
    [SerializeField] 
    private GameObject sphere;
    private ReactiveProperty<int> intRP = new ReactiveProperty<int>();
    private ReactiveProperty<string> strRP = new ReactiveProperty<string>();

    // Start is called before the first frame update
    void Start()
    {
        intRP.Value = 0;
        intRP.SetValueAndForceNotify(0);
        intRP.Select(x => Unit.Default).Merge(strRP.Select(x=>Unit.Default)).Subscribe
            (_ =>
            {
                Debug.Log("´¥·¢ÁË");
            });
       
        box.OnMouseDownAsObservable().Subscribe(_ => { intRP.Value += 1; });
        sphere.OnMouseDownAsObservable().Subscribe(_ => { strRP.Value = Guid.NewGuid().ToString(); });
    }

}
