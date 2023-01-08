using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private new SpriteRenderer renderer;
    [SerializeField] private SpriteMask mask;

    public int order;

    public void Init(bool isOffset, int _order)
    {
        renderer.color = isOffset ? offsetColor : baseColor;

        renderer.sortingLayerName = "Crops";
        order = _order;
        renderer.sortingOrder = order;

        mask.isCustomRangeActive = true;
        mask.backSortingLayerID = SortingLayer.NameToID("Crops");
        mask.backSortingOrder = order - 1;
        mask.frontSortingLayerID = SortingLayer.NameToID("Crops");
        mask.frontSortingOrder = order;
    }
}
