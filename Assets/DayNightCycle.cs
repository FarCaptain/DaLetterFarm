using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private Transform clockHandHolder;
    [SerializeField] private float dayDuration = 120f;

    [SerializeField] private float startDelay = 2f;

    // 360 -> 210,100,50
    private float dayAngle = 0f;
    private float duskAngle = -210f;
    private float nightAngle = -310f;

    private float accumulatedTime = 0f;

    private void Start()
    {
        // get rid of the smoothness
        //InvokeRepeating("UpdateCountDown", startDelay, 0.1f);
    }

    private void Update()
    {
        if (startDelay > 0f)
        {
            startDelay -= Time.deltaTime;
        }
        else
        {
            UpdateCountDown();
        }
    }

    private void UpdateCountDown()
    {
        accumulatedTime += Time.deltaTime;
        if(accumulatedTime >= dayDuration)
            accumulatedTime %= dayDuration;

        float angle = -360f / dayDuration * accumulatedTime;
        angle %= 360;

        clockHandHolder.eulerAngles = new Vector3(0f, 0f, angle);
    }
}
