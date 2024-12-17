using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Diablo/DerivedStat", fileName = "Stat")]
public class SO_DerivedStat : ScriptableObject
{
    public string DerivedStatName;

    [SerializeField] List<SO_Stat> stats;
    [SerializeField] List<float> multipliers;

    public float DerivedStatBaseValue()
    {
        float totalValue = 0;

        for (int i = 0; i < stats.Count; i++)
        {
           totalValue += stats[i].BaseValue * multipliers[i];
        }

        return totalValue;
    }
}
