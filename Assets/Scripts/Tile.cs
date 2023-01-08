using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Sprite baseTile, offsetTile;
    [SerializeField] private new SpriteRenderer renderer;

    public void Init(bool isOffset)
    {
        renderer.sprite = isOffset ? offsetTile : baseTile;
    }
}
