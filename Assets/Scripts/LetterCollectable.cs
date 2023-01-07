using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LetterCollectable : MonoBehaviour
{
    public char letter;
    public UnityEvent OnClick;
    public WordPanel wordPanel;

    private void OnMouseDown()
    {
        OnClick?.Invoke();
        wordPanel.AddLetter(letter);
        Destroy(gameObject, 0.2f);
    }
}
