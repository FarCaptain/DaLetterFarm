using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SeedPossibilities", menuName = "Sphinx/Design/SeedPossibilities")]
public class SeedPossibilities : ScriptableObject
{
    public List<SeedSpawningChance> spawningChances;

    private List<float> accumulatedChance;

    private void Awake()
    {
        float chance = 0f;
        accumulatedChance = new List<float>();
        for (int i = 0; i < spawningChances.Count; i++)
        {
            chance += spawningChances[i].chancePercentage;
            accumulatedChance.Add(chance);
        }

        if (chance > 100f)
            Debug.LogWarning($"chance Reached {chance} !");
    }

    public int GetRandomLetterIndex()
    {
        float num = Random.Range(0f, 100f);
        for (int i = 0; i < accumulatedChance.Count; i++)
        {
            if (num <= accumulatedChance[i])
                return i;
        }
        return -1;
    }
}
