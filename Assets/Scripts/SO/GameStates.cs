using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameStates", menuName = "Sphinx/GameStates")]
public class GameStates : ScriptableObject
{
    public GameTimeState timeState;
}

public enum GameTimeState
{
    DAY,
    DUSK,
    NIGHT,
    EMPTY
}
