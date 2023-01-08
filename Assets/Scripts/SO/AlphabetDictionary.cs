using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AlphabetDictionary", menuName = "Sphinx/AlphabetDictionary")]
public class AlphabetDictionary : ScriptableObject
{
    public Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
}
