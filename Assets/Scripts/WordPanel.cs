using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordPanel : MonoBehaviour
{
    private string currentWord;
    [SerializeField] private TextMeshProUGUI content;
    [SerializeField] private AlphabetDictionary dict;

    public void AddLetter(char letter)
    {
        currentWord += letter;
        content.text = currentWord;
    }

    public void CheckWord()
    {
        bool isWord = dict.dictionary.TryGetValue(currentWord, out bool isChecked);
        if (isWord && !isChecked)
        {
            Debug.Log(currentWord + "Yeah!");
            dict.dictionary[currentWord] = true;
        }
        else
        {
            Debug.Log(currentWord + "Nooooo");
        }
        currentWord = "";
        content.text = "";
    }
}
