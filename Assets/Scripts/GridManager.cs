using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private Tile tilePrefab;

    [SerializeField] private Transform gridGroup;
    [SerializeField] private GridMap gridMap;

    [SerializeField] private Transform fieldAnchor;

    // hard code
    [SerializeField] private Vector2 tileSize = new Vector2(2.53f, 1.84f);

    private void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        ClearGrid();
        gridMap.tiles = new Dictionary<Tile, char>();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // spawn at a local position
                var spawnedTile = Instantiate(tilePrefab, transform.position + new Vector3(x * tileSize.x, y * tileSize.y), Quaternion.identity, gridGroup);
                spawnedTile.name = $"Tile {x} {y}";

                bool isOffset = (x + y) % 2 == 1;
                spawnedTile.Init(isOffset, fieldAnchor);

                // ' ' for empty tile
                gridMap.tiles[spawnedTile] = ' ';
            }
        }
    }

    private void ClearGrid()
    {
        for (int i = gridGroup.childCount - 1; i >= 0 ; i--)
        {
            DestroyImmediate(gridGroup.GetChild(i).gameObject);
        }
    }
}
