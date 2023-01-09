using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Sprite baseTile, offsetTile;
    [SerializeField] private new SpriteRenderer renderer;

    private Transform tileAnchor;
    public void Init(bool isOffset, Transform _anchor)
    {
        renderer.sprite = isOffset ? offsetTile : baseTile;
        tileAnchor = _anchor;
    }

    public Vector3 GetAnchoredPosition()
    {
        return transform.position + tileAnchor.position;
    }
}
