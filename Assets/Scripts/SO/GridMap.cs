using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GridMap", menuName = "Sphinx/GridMap")]
public class GridMap : ScriptableObject
{
    public Dictionary<Tile, char> tiles;

    public char GetLetterAtTile(Tile _tile)
    {
        if (tiles.TryGetValue(_tile, out var letter))
        {
            return letter;
        }
        return ' ';
    }
}
