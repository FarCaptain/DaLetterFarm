using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordPanel : MonoBehaviour
{
    [SerializeField] private CurrentWord currentWord;
    [SerializeField] private TextMeshProUGUI content;
    [SerializeField] private AlphabetDictionary dict;

    private void OnEnable()
    {
        currentWord.word = "";
    }

    public void CheckWord()
    {
        bool isWord = dict.dictionary.TryGetValue(currentWord.word, out bool isChecked);
        if (isWord && !isChecked)
        {
            Debug.Log(currentWord + "Yeah!");
            dict.dictionary[currentWord.word] = true;
        }
        else
        {
            Debug.Log(currentWord + "Nooooo");
        }
        currentWord.word = "";
        content.text = "";
    }

    private void Update()
    {
        content.text = currentWord.word;
    }
}
