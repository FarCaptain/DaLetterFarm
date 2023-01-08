using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private new SpriteRenderer renderer;
    [SerializeField] private PlantCollection plantCollection;

    [SerializeField] private LetterCollectable fruitPrefab;
    [SerializeField] private LetterAttributs attribs;

    [SerializeField] private GridMap gridMap;

    private float spawnTime = 0f;
    private float accumulatedTime = 0f;

    private float durationTime = 0f;
    private float accTime = 0f;

    private int letterIndex;
    // keep a tile reference
    private Tile tile;

    public void Init(int _index, Tile _tile)
    {
        renderer.sprite = plantCollection.sprites[_index];

        letterIndex = _index;
        tile = _tile;

        spawnTime = attribs.attribSet[letterIndex].growTime;
        durationTime = attribs.attribSet[letterIndex].durability;
    }

    private void Update()
    {
        accumulatedTime += Time.deltaTime;
        if (accumulatedTime > spawnTime)
        {
            accumulatedTime = 0;
            SpawnFruit();
        }

        accTime += Time.deltaTime;
        if(accTime > durationTime)
        {
            accTime = 0;
            gridMap.tiles[tile] = ' ';
            Destroy(gameObject, 0.01f);
        }
    }

    private void SpawnFruit()
    {
        // hard code position
        Vector3 offset = new Vector3(Random.Range(-1.3f, 1.3f), Random.Range(-0.7f, 0.01f));
        var frt = Instantiate(fruitPrefab, transform.position + offset, Quaternion.identity);
        frt.Init(letterIndex);
    }
}
