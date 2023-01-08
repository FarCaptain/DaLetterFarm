using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPanel : MonoBehaviour
{
    [SerializeField] private LetterSeed seedPrefab;
    [SerializeField] private LetterInventory inventory;

    private void Start()
    {
        GeneratePanel();
    }

    private void GeneratePanel()
    {
        for (int i = 0; i < inventory.letters.Count; i++)
        {
            var spawnedSeed = Instantiate(seedPrefab, transform);
            spawnedSeed.Init(inventory.letters[i]);
        }
    }
}
