using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LetterInventory", menuName = "Sphinx/LetterInventory")]
public class LetterInventory : ScriptableObject
{
    public int capacity = 8;
    [SerializeField] private SeedPossibilities seedPossibilities;
    //public List<char> letters = new List<char>();

    public char AddNewLetter()
    {
        int idx = seedPossibilities.GetRandomLetterIndex();
        if(idx == -1)
        {
            Debug.LogError("Letter Error");
            return ' ';
        }

        char letter = (char)('A' + idx);
        //letters.Add(letter);
        return letter;
    }
}
