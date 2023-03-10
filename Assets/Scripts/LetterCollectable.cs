using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

/// <summary>
/// Fruit
/// </summary>
public class LetterCollectable : MonoBehaviour
{
    public char letter;
    [SerializeField] private CurrentWord currentWord;
    [SerializeField] private FruitCollection fruitCollection;
    [SerializeField] private new SpriteRenderer renderer;

    [SerializeField] private LetterAttributs attribs;
    [SerializeField] private GameStates gameStates;

    [SerializeField] private Timer keepTimer;

    public void Init(int _index)
    {
        letter = (char)('A' + _index);
        renderer.sprite = fruitCollection.sprites[_index];

        float keepTime = attribs.attribSet[_index].keepTime;
        keepTimer.ResetTimer(keepTime, true);
    }

    public void OnClicked()
    {
        // apply limit
        if(currentWord.GetWord().Length < 15)
            currentWord.SetWord(currentWord.GetWord() + letter);
        AudioManager.instance.Play("collectfruit");
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if(!gameStates.GetShovelState())
            OnClicked();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
