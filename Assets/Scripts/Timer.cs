using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private string timerName;

    private float accumulatedTime = 0f;
    private float targetTime = 0f;
    private bool started = false;

    public UnityEvent OnTimeUp;

    public void ResetTimer(float _targetTime, bool _started = false)
    {
        targetTime = _targetTime;
        accumulatedTime = 0f;
        started = _started;
    }

    public void StartTimer()
    {
        started = true;
    }

    public void StopTimer()
    {
        started = false;
    }


    private void Update()
    {
        if (!started)
            return;

        accumulatedTime += Time.deltaTime;
        if (accumulatedTime > targetTime)
        {
            accumulatedTime = 0;
            OnTimeUp?.Invoke();
        }
    }
}
