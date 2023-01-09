using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantCollection", menuName = "Sphinx/PlantCollection")]
public class PlantCollection : ScriptableObject
{
    // hacky, but where we end up
    public List<SpriteRenderer> spritePrefabs;
}
