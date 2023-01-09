using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LetterSeed : MonoBehaviour
{
    private char letter;
    //[SerializeField] private TextMeshProUGUI content;
    [SerializeField] private Image image;

    [SerializeField] private SeedCollection seeds;
    [SerializeField] private PlantCollection plants;

    //empty plant prefab
    [SerializeField] private Plant plantPrefab;
    [SerializeField] private GridMap gridMap;
    [SerializeField] private LetterInventory letterInventory;

    public void Init(char _letter)
    {
        letter = _letter;
        //content.text = "" + letter;

        int idx = GetIndex();
        if(idx != -1)
        {
            image.sprite = seeds.sprites[idx];
        }
    }

    public void PlantLetter()
    {
        int idx = GetIndex();
        if (idx == -1)
            return;

        // find avalible position
        foreach (KeyValuePair<Tile, char> entry in gridMap.tiles)
        {
            if(entry.Value == ' ')
            {
                var tile = entry.Key;
                var pos = tile.GetAnchoredPosition();
                var spawnedPlant = Instantiate(plantPrefab, pos, Quaternion.identity);

                spawnedPlant.Init(idx, tile);

                gridMap.tiles[tile] = letter;

                Debug.Log($"Planted {letter} !");
                Destroy(gameObject);
                return;
            }
        }
    }

    private int GetIndex()
    {
        string str = letter.ToString();
        if (str == " ") return -1;

        str = str.ToUpper();
        return (str[0] - 'A');
    }
}
