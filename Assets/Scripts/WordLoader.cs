using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

public class WordLoader : MonoBehaviour
{
    public AlphabetDictionary alphabetDictionary;
    private Dictionary<string, bool> dict;

    [SerializeField] private TextAsset file;
    private void Start()
    {
        InitDictionary();
        Debug.Log("DictionaryLoaded!");

        dict = alphabetDictionary.dictionary;
    }

    public void CheckWord(string _word)
    {
        bool isWord = dict.TryGetValue(_word, out bool isChecked);
        if(isWord && !isChecked)
        {
            Debug.Log("Yeah!");
            dict[_word] = true;
        }
        else
        {
            Debug.Log("Nooooo");
        }
    }

    private void InitDictionary()
    {
        // keep the asset after build and adopt to all plateforms
        var lines = Regex.Split(file.text, "\r\n|\r|\n");

        foreach (var line in lines)
        {
            Debug.Log(line);
            alphabetDictionary.dictionary.Add(line.ToUpper(), false);
        }
    }
}
