using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPanel : MonoBehaviour
{
    [SerializeField] private LetterSeed seedPrefab;
    [SerializeField] private LetterInventory inventory;

    private void Start()
    {
        UpdatePanel();
    }

    private void UpdatePanel()
    {
        int seedNumber = transform.childCount;
        int num = inventory.capacity - seedNumber;
        for (int i = 0; i < num; i++)
        {
            var spawnedSeed = Instantiate(seedPrefab, transform);
            char spawnedLetter = inventory.AddNewLetter();
            spawnedSeed.Init(spawnedLetter);
        }
    }

    private void Update()
    {
        UpdatePanel();
    }
}
