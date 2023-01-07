using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class LetterCollectable : MonoBehaviour
{
    public char letter;
    public WordPanel wordPanel;

    private void OnEnable()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = "" + letter;
    }

    public void OnClicked()
    {
        wordPanel.AddLetter(letter);
        Destroy(gameObject, 0.2f);
    }
}
