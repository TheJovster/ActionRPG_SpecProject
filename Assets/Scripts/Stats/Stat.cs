using System;
using UnityEngine;


namespace Stats
{
    [Tooltip("Current Value and the Base Value need to be set as the same value on initialization.")]
    [Serializable]
    public class Stat
    {
        public StatType StatType;
        public float CurrentValue;
        public float BaseValue;

        public Stat(StatType statType, float currentvalue, float baseValue)
        {
            StatType = statType;
            BaseValue = baseValue;
            CurrentValue = currentvalue;
        }
        
        public void IncrementValue()
        {
            ++CurrentValue;
        }

        public void SaveChanges()
        {
            //for UI
        }
    }
    
    [Serializable]
    public enum StatType
    {
        Strength,
        Vitality,
        Dexterity,
        Magic
    }
}

