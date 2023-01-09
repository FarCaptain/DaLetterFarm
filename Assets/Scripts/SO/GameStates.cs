using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameStates", menuName = "Sphinx/GameStates")]
public class GameStates : ScriptableObject
{
    public GameTimeState timeState;

    private bool usingShovel = false;

    public delegate void ShovelStateDelegate();
    public event ShovelStateDelegate onShovelStateChanged;

    public void SetShovelState(bool _state)
    {
        if (_state == usingShovel)
            return;

        usingShovel = _state;
        onShovelStateChanged?.Invoke();
    }

    public bool GetShovelState() => usingShovel;
}

public enum GameTimeState
{
    DAY,
    DUSK,
    NIGHT,
    EMPTY
}
