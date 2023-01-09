using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Word", menuName = "Sphinx/Word")]
public class CurrentWord : ScriptableObject
{
    private string word;

    public delegate void WordChangeDelegate();
    public event WordChangeDelegate onCurrentWordChanged;

    public void SetWord(string _word)
    {
        if (_word == word)
            return;

        word = _word;
        onCurrentWordChanged?.Invoke();
    }

    public string GetWord() => word;
}
