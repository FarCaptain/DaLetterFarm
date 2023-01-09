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
        states.usingShovel = false;
    }

    public void UseShovel()
    {
        states.usingShovel = true;
        blockPanel.SetActive(true);
    }

    public void LetGoShovel()
    {
        states.usingShovel = false;
        blockPanel.SetActive(false);
    }

    public void ToggleShovel()
    {
        if (states.usingShovel)
            LetGoShovel();
        else
            UseShovel();
    }
}
