using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private new SpriteRenderer renderer;
    [SerializeField] private PlantCollection plantCollection;

    [SerializeField] private LetterCollectable fruitPrefab;
    [SerializeField] private LetterAttributs dayAttribs;
    [SerializeField] private LetterAttributs duskAttribs;

    [SerializeField] private GridMap gridMap;

    // have to keep all remained timer for four processes
    [SerializeField] private Timer dayFruitSpawningTimer;
    [SerializeField] private Timer dayPlantDurationTimer;
    [SerializeField] private Timer duskFruitSpawningTimer;
    [SerializeField] private Timer duskPlantDurationTimer;
    [SerializeField] private GameStates gameStates;

    [SerializeField] private Color warningColor;
    private Color originalColor;

    private float daySpawnTime = 0f;
    private float dayDurationTime = 0f;

    private float duskSpawnTime = 0f;
    private float duskDurationTime = 0f;

    private int letterIndex;
    // keep a tile reference
    private Tile tile;

    private GameTimeState timeState = GameTimeState.EMPTY;

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

        daySpawnTime = dayAttribs.attribSet[letterIndex].growTime;
        dayDurationTime = dayAttribs.attribSet[letterIndex].durability;

        duskSpawnTime = duskAttribs.attribSet[letterIndex].growTime;
        duskDurationTime = duskAttribs.attribSet[letterIndex].durability;

        timeState = GameTimeState.EMPTY;
        InitTimers();
        UpdateStates();
    }

    private void Update()
    {
        UpdateStates();
    }

    private void UpdateStates()
    {
        if (timeState == gameStates.timeState)
            return;

        timeState = gameStates.timeState;
        StopAllTimers();
        switch (timeState)
        {
            case GameTimeState.DAY:
                if (daySpawnTime == -1) break;
                dayFruitSpawningTimer.StartTimer();
                dayPlantDurationTimer.StartTimer();
                break;
            case GameTimeState.DUSK:
                if (duskSpawnTime == -1) break;
                duskFruitSpawningTimer.StartTimer();
                duskPlantDurationTimer.StartTimer();
                break;
            case GameTimeState.NIGHT:
                break;
            case GameTimeState.EMPTY:
                Debug.LogError("undefined gamestate");
                break;
            default:
                Debug.LogError("undefined gamestate");
                break;
        }
    }

    private void InitTimers()
    {
        dayFruitSpawningTimer.ResetTimer(daySpawnTime, false);
        dayPlantDurationTimer.ResetTimer(dayDurationTime, false);

        duskFruitSpawningTimer.ResetTimer(duskSpawnTime, false);
        duskPlantDurationTimer.ResetTimer(duskDurationTime, false);
    }

    private void StopAllTimers()
    {
        dayFruitSpawningTimer.StopTimer();
        dayPlantDurationTimer.StopTimer();
        duskFruitSpawningTimer.StopTimer();
        duskPlantDurationTimer.StopTimer();
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
        if(gameStates.usingShovel)
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
        if(gameStates.usingShovel)
        {
            Die();
        }
    }
}
