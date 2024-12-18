using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.UIElements;

namespace Stats
{
    [Serializable]
    public class DerivedAttributes
    {
        //might be unsafe to leave these public
        //consider refactoring
        public DerivedAttributeType DerivedAttributeType;
        public float DerivedAttributeBaseValue;
        public float DerivedAttributeMinValue = 0;
        public float DerivedAttributeCurrentValue;
        public float DerivedAttributeMaxValue;
        public float PerStatModifier = 1.2f; //maybe move to CharacterClass?

        
    }
    
    [Serializable]
    public enum DerivedAttributeType
    {
        Health,
        Mana,
        BaseDamage
    }
}

