using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer renderer;

    public void Init(bool isOffset, int order)
    {
        renderer.color = isOffset ? offsetColor : baseColor;

        renderer.sortingLayerName = "Crops";
        renderer.sortingOrder = order;
    }
}
