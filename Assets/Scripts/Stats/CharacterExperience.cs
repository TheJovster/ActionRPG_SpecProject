using System;
using UnityEngine;

namespace Stats
{
    [Serializable]
    public class CharacterExperience
    {
        public float CurrentExperience = 0; //initialized at 0
        public int CurrentLevel = 1; //initalized at 1
        public float EXPUntilNextLevel; //unitinailzed
        public float EXPPerLevelRequirement = 1000;
        public float EXPPerLevelModifier = 1.5f;
        
        public void RecalculateExpUntilNextLevel()
        {
            EXPUntilNextLevel = EXPPerLevelRequirement * EXPPerLevelModifier * CurrentLevel;
        }
        
        
    }
}

