using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private Transform clockHandHolder;
    [SerializeField] private float startAngle = -60f;
    [SerializeField] private float dayDuration = 120f;

    [SerializeField] private float startDelay = 2f;

    [SerializeField] private GameStates gameStates;

    // 360 -> 210,100,50 absolute value
    private float dayAngle = 0f;
    private float duskAngle = 210f;
    private float nightAngle = 310f;

    [SerializeField] private Volume volume;
    // project range to 0 ~ 360 -> 0 ~3.6 to make life easier
    [SerializeField] private AnimationCurve volumeCurve;

    //[SerializeField] private Light2D nightLight;
    [SerializeField] private AnimationCurve lightCurve;

    private float accumulatedTime = 0f;

    private void Start()
    {
        // get rid of the smoothness
        //InvokeRepeating("UpdateCountDown", startDelay, 0.1f);
        Init();
    }

    private void Init()
    {
        float angle = startAngle % 360;
        clockHandHolder.eulerAngles = new Vector3(0f, 0f, angle);

        float projectedAngle = -1 * angle * 0.01f;
        float ligthIntensity = volumeCurve.Evaluate(projectedAngle);
        volume.weight = 1f - ligthIntensity;

        //nightLight.intensity = lightCurve.Evaluate(projectedAngle);

        // init time state
        UpdateTimeState(angle);
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

        float angle = startAngle + (-360f / dayDuration * accumulatedTime);
        angle %= 360;

        clockHandHolder.eulerAngles = new Vector3(0f, 0f, angle);

        // project to 0 ~ 3.6
        float projectedAngle = -1 * angle * 0.01f;
        float ligthIntensity = volumeCurve.Evaluate(projectedAngle);
        volume.weight = 1f - ligthIntensity;

        //nightLight.intensity = lightCurve.Evaluate(projectedAngle);
        //Debug.Log($"[Angles] {angle} => {projectedAngle}");

        UpdateTimeState(angle);
    }

    private void UpdateTimeState(float _angle)
    {
        _angle = Mathf.Abs(_angle);

        if (_angle < duskAngle)
            gameStates.SetTimeState(GameTimeState.DAY);
        else if (_angle < nightAngle)
            gameStates.SetTimeState(GameTimeState.DUSK);
        else
            gameStates.SetTimeState(GameTimeState.NIGHT);

        //Debug.Log($"[GameState] {gameStates.timeState} at {_angle}");
    }

    private void OnValidate()
    {
        Init();
    }
}
