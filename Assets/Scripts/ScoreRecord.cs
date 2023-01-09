using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRecord : MonoBehaviour
{
    [SerializeField] private Text scoreRecord;
    [SerializeField] private Text letterHistory;
    [SerializeField] private int capacity = 5;
    private int wordCount = 0;
    private int score = 0;

    void Update()
    {
        scoreRecord.text = "Score: " + score;
    }

    public void AddScore(int _length)
    {
        #region
        // 1~3 1
        // 4~6 3
        // 7~9 5
        // 10 ~ 12 7
        // 13 ~ 15 9
        #endregion

        if (_length <= 3)
            score += 1;
        else if (_length <= 6)
            score += 3;
        else if (_length <= 9)
            score += 5;
        else if (_length <= 12)
            score += 7;
        else
            score += 9;
    }

    public void ShowWord(string _word)
    {
        letterHistory.text += _word + "\n";
        wordCount++;

        //    if(wordCount > capacity)
        //    {
        //        letterHistory.text.Split()
        //    }
    }
}
