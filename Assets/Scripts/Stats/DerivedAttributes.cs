using UnityEngine;
using System;

namespace Stats
{
    [Serializable]
    public class DerivedAttributes
    {
        public DerivedAttributeType DerivedAttributeType;
        public float DerivedAttributeValue;
        public float DerivedAttributeBaseValue;
        public float DerivedAttributeMinValue;
        public float DerivededAttirbuteCurrentValue;
        
    }
    
    [Serializable]
    public enum DerivedAttributeType
    {
        Health,
        Mana,
        BaseDamage
    }
}

