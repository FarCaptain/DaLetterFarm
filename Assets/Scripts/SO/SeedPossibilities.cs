using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SeedPossibilities", menuName = "Sphinx/Design/SeedPossibilities")]
public class SeedPossibilities : ScriptableObject
{
    public List<SeedSpawningChance> spawningChances;
}
