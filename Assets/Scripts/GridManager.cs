using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Transform cam;

    [SerializeField] private Transform gridGroup;

    private Dictionary<Tile, char> tiles;

    private void Start()
    {
        //GenerateGrid();
    }

    public void GenerateGrid()
    {
        ClearGrid();
        tiles = new Dictionary<Tile, char>();

        var tileSize = tilePrefab.transform.localScale;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x * tileSize.x, y * tileSize.y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                bool isOffset = (x + y) % 2 == 1;
                spawnedTile.Init(isOffset, 4 - y);
                spawnedTile.transform.parent = gridGroup;

                // space for empty tile
                tiles[spawnedTile] = ' ';
            }
        }

        cam.position = new Vector3((float)(width - 1) * tileSize.x / 2, (float)(height - 1) * tileSize.y / 2, -10);
    }

    private void ClearGrid()
    {
        for (int i = gridGroup.childCount - 1; i >= 0 ; i--)
        {
            DestroyImmediate(gridGroup.GetChild(i).gameObject);
        }
    }

    public char GetLetterAtTile(Tile _tile)
    {
        if(tiles.TryGetValue(_tile, out var letter))
        {
            return letter;
        }
        return ' ';
    }
}
