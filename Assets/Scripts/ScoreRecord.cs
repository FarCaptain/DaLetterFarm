using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRecord : MonoBehaviour
{
    [SerializeField] private Text scoreRecord;
    [SerializeField] private Text letterHistoryPrefab;
    [SerializeField] private Transform letterHistoryParent;
    [SerializeField] private int capacity = 5;

    [SerializeField] private ResultTicketfix fixes;
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

    public void ShowWord(string _word, bool _isWord, bool _isChecked)
    {
        var letterHistory = Instantiate(letterHistoryPrefab, letterHistoryParent);

        LineFix fix;
        if(!_isWord)
        {
            int index = Random.Range(0, fixes.wrongFixes.Count);
            fix = fixes.wrongFixes[index];
        }
        else if(_isChecked)
        {
            int index = Random.Range(0, fixes.repeatFixes.Count);
            fix = fixes.repeatFixes[index];
        }
        else
        {
            int index = Random.Range(0, fixes.correctFixes.Count);
            fix = fixes.correctFixes[index];
        }
        letterHistory.text = fix.prefix + " " + _word + " " + fix.suffix;
    }
}
