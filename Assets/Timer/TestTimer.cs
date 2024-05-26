using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TestTimer : MonoBehaviour
{
    ConcurrentTimer timer = new ConcurrentTimer();

    // Start is called before the first frame update
    void Start()
    {
        timer.OnTimerStart.Subscribe(x => { print("��ʼ��ʱ��"); });
        timer.OnTimeCountdownNormalized.Subscribe(x => { print($"��ǰʱ��Ϊ��{x}"); });
        timer.OnTimerEnd.Subscribe(x => { print("��������ʱ"); });
        timer.StartTimer(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
