using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WordPanel : MonoBehaviour
{
    [SerializeField] private CurrentWord currentWord;
    [SerializeField] private TextMeshProUGUI content;
    [SerializeField] private AlphabetDictionary dict;
    [SerializeField] private FruitCollection fruitCollection;
    [SerializeField] private Image letterUIPrefab;
    [SerializeField] private ScoreRecord scoreRecord;

    [SerializeField] private int capacity = 15;

    private void OnEnable()
    {
        currentWord.onCurrentWordChanged += UpdateLettersOnPanel;

        currentWord.SetWord("");
    }

    private void OnDisable()
    {
        currentWord.onCurrentWordChanged -= UpdateLettersOnPanel;
    }

    public void CheckWord()
    {
        scoreRecord.ShowWord(currentWord.GetWord());
        bool isWord = dict.dictionary.TryGetValue(currentWord.GetWord(), out bool isChecked);
        if (isWord && !isChecked)
        {
            Debug.Log(currentWord + "Yeah!");

            int length = currentWord.GetWord().Length;
            scoreRecord.AddScore(length);
            dict.dictionary[currentWord.GetWord()] = true;
        }
        else
        {
            Debug.Log(currentWord + "Nooooo");
        }
        currentWord.SetWord("");
        content.text = "";
    }

    private void Update()
    {
        content.text = currentWord.GetWord();
    }


    private void UpdateLettersOnPanel()
    {
        //clean up all
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        foreach (var letter in currentWord.GetWord())
        {
            var letterImage = Instantiate(letterUIPrefab, transform);
            letterImage.sprite = fruitCollection.sprites[letter - 'A'];
        }
    }

}
