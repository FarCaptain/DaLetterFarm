using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LetterInventory", menuName = "Sphinx/LetterInventory")]
public class LetterInventory : ScriptableObject
{
    public List<char> letters = new List<char>();
}
