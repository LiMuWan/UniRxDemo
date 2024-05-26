using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

/// <summary>
/// 并发计时器
/// </summary>
public class ConcurrentTimer
{ 
   private Subject<Unit> onTimerStart = new Subject<Unit>();
   private Subject<Unit> onTimerEnd = new Subject<Unit>();
   private FloatReactiveProperty timeCountdown = new FloatReactiveProperty();
   private FloatReactiveProperty timeCountdownNormalized = new FloatReactiveProperty();
   private IDisposable processForTimer = null;

   public IObservable<Unit> OnTimerStart => onTimerStart;
   public IObservable<Unit> OnTimerEnd => onTimerEnd;

   public IObservable<float> OnTimeCountdown => timeCountdown;
   public IObservable<float> OnTimeCountdownNormalized => timeCountdownNormalized;

   public void StartTimer(float countTime)
    {
        var timer = countTime;
        float timer_normalized = 0;

        onTimerStart.OnNext(Unit.Default);
        processForTimer = Observable.EveryLateUpdate().Subscribe(x =>
        {
            timer -= Time.deltaTime;
            timer = Math.Clamp(timer, 0, countTime);
            timer_normalized = timer / countTime;
            timeCountdownNormalized.Value = timer_normalized;

            if(timer <= 0)
            {
                //释放掉计时线程
                processForTimer.Dispose();
                onTimerEnd.OnNext(Unit.Default);
            }
        });
    }
    
}
