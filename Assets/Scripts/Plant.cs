using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private new SpriteRenderer renderer;
    [SerializeField] private PlantCollection plantCollection;

    public void Init(int _order, int _index)
    {
        renderer.sortingLayerName = "Crops";
        renderer.sortingOrder = _order;

        renderer.sprite = plantCollection.sprites[_index];
    }
}
