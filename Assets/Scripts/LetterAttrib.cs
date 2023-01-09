using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LetterAttrib
{
    public char letter;
    public GameTimeState growState;
    public float growTime;
    public float keepTime;
    public float durability;
}