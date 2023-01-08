using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LetterInventory", menuName = "Sphinx/LetterInventory")]
public class LetterInventory : ScriptableObject
{
    [SerializeField] private int capacity = 8;
    [SerializeField] private SeedPossibilities seedPossibilities;
    public List<char> letters = new List<char>();

}
