using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WordLoader : MonoBehaviour
{
    public AlphabetDictionary alphabetDictionary;
    private Dictionary<string, bool> dict;
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
        StreamReader sr = new StreamReader("Assets/Resources/words_alpha.txt");
        while (!sr.EndOfStream)
        {
            string word = sr.ReadLine();
            alphabetDictionary.dictionary.Add(word.ToUpper(), false);
        }
    }
}
