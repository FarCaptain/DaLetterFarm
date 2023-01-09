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

    // have to keep all remained timer for four processes
    [SerializeField] private Timer fruitSpawningTimer;
    [SerializeField] private Timer plantDurationTimer;
    [SerializeField] private GameStates gameStates;

    [SerializeField] private Color warningColor;
    private Color originalColor;

    //in what state the plant grow
    private GameTimeState growingState = GameTimeState.DAY;

    private int letterIndex;
    // keep a tile reference
    private Tile tile;

    private void OnEnable()
    {
        gameStates.onShovelStateChanged += UpdateShovelState;
        gameStates.onTimeStateChanged += UpdateTimeStates;
    }

    private void OnDisable()
    {
        gameStates.onShovelStateChanged -= UpdateShovelState;
        gameStates.onTimeStateChanged -= UpdateTimeStates;
    }

    private void Start()
    {
        originalColor = renderer.color;
    }

    public void Init(int _index, Tile _tile)
    {
        // we want position and sprites, sort of a hack
        var plantdata = plantCollection.spritePrefabs[_index];
        renderer.sprite = plantdata.sprite;
        transform.localPosition = plantdata.transform.position;
        transform.localPosition += _tile.transform.localPosition;

        letterIndex = _index;
        tile = _tile;

        growingState = attribs.attribSet[letterIndex].growState;
        float spawnTime = attribs.attribSet[letterIndex].growTime;
        float durationTime = attribs.attribSet[letterIndex].durability;

        InitTimers(spawnTime, durationTime);
    }

    private void UpdateTimeStates()
    {
        // garenteed different
        StopAllTimers();
        var globalState = gameStates.GetTimeState();
        if (globalState == growingState)
        {
            fruitSpawningTimer.StartTimer();
            plantDurationTimer.StartTimer();
        }
        // else stop
    }

    private void UpdateShovelState()
    {
        if(gameStates.GetShovelState())
        {
            renderer.sortingLayerName = "Front";
        }
        else
        {
            renderer.sortingLayerName = "Crops";
        }
    }

    private void InitTimers(float _spawnTime, float _durationTime)
    {
        fruitSpawningTimer.ResetTimer(_spawnTime, false);
        plantDurationTimer.ResetTimer(_durationTime, false);

        var globalState = gameStates.GetTimeState();
        if (globalState == growingState)
        {
            fruitSpawningTimer.StartTimer();
            plantDurationTimer.StartTimer();
        }
    }

    private void StopAllTimers()
    {
        fruitSpawningTimer.StopTimer();
        plantDurationTimer.StopTimer();
    }

    public void SpawnFruit()
    {
        // hard code position
        Vector3 offset = new Vector3(Random.Range(-1.3f, 1.3f), Random.Range(-0.7f, 0.01f));
        var frt = Instantiate(fruitPrefab, transform.position + offset, Quaternion.identity);
        frt.Init(letterIndex);
    }

    public void Die()
    {
        gridMap.tiles[tile] = ' ';
        Destroy(gameObject, 0.005f);
    }

    private void OnMouseEnter()
    {
        if(gameStates.GetShovelState())
        {
            originalColor = renderer.color;
            renderer.color = warningColor;
        }
    }

    private void OnMouseExit()
    {
        renderer.color = originalColor;
    }

    private void OnMouseDown()
    {
        if(gameStates.GetShovelState())
        {
            AudioManager.instance.Play("shovel");
            Die();
        }
    }
}
