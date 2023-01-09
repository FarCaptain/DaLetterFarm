using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shovel : MonoBehaviour
{
    [SerializeField] private Button shovelButton;
    [SerializeField] private GameStates states;
    [SerializeField] private GameObject blockPanel;


    private void Awake()
    {
        states.SetShovelState(false);
    }

    public void UseShovel()
    {
        states.SetShovelState(true);
        blockPanel.SetActive(true);
    }

    public void LetGoShovel()
    {
        states.SetShovelState(false);
        blockPanel.SetActive(false);
    }

    public void ToggleShovel()
    {
        if (states.GetShovelState())
            LetGoShovel();
        else
            UseShovel();
    }
}
