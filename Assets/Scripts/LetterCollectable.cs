using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class LetterCollectable : MonoBehaviour
{
    public char letter;
    [SerializeField] private CurrentWord currentWord;
    [SerializeField] private FruitCollection fruitCollection;
    [SerializeField] private new SpriteRenderer renderer;

    [SerializeField] private LetterAttributs attributs;
    private float keepTime = 0;
    private float accTime = 0;

    public void Init(int _index)
    {
        letter = (char)('A' + _index);
        renderer.sprite = fruitCollection.sprites[_index];

        keepTime = attributs.attribSet[_index].keepTime;
    }

    public void OnClicked()
    {
        currentWord.word += letter;
        Destroy(gameObject, 0.2f);
    }

    private void OnMouseDown()
    {
        OnClicked();
    }

    private void Update()
    {
        accTime += Time.deltaTime;
        if(accTime > keepTime)
        {
            accTime = 0;
            Destroy(gameObject);
        }
    }
}
