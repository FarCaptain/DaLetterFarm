using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameStates", menuName = "Sphinx/GameStates")]
public class GameStates : ScriptableObject
{
    private GameTimeState timeState;

    private bool usingShovel = false;

    public delegate void ShovelStateDelegate();
    public event ShovelStateDelegate onShovelStateChanged;

    public delegate void TimeStateDelegate();
    public event ShovelStateDelegate onTimeStateChanged;

    public void SetShovelState(bool _state)
    {
        if (_state == usingShovel)
            return;

        usingShovel = _state;
        onShovelStateChanged?.Invoke();
    }

    public bool GetShovelState() => usingShovel;


    public void SetTimeState(GameTimeState _state)
    {
        if (_state == timeState)
            return;

        timeState = _state;
        onTimeStateChanged?.Invoke();
    }

    public GameTimeState GetTimeState() => timeState;
}

public enum GameTimeState
{
    DAY,
    DUSK,
    NIGHT,
    EMPTY
}
