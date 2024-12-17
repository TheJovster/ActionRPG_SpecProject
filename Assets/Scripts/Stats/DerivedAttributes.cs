using UnityEngine;
using System;
using Unity.VisualScripting;

namespace Stats
{
    [Serializable]
    public class DerivedAttributes
    {
        public DerivedAttributeType DerivedAttributeType;
        public float DerivedAttributeBaseValue;
        public float DerivedAttributeMinValue = 0;
        public float DerivedAttributeCurrentValue;
        public float PerStatModifier = 1.2f;


    }
    
    [Serializable]
    public enum DerivedAttributeType
    {
        Health,
        Mana,
        BaseDamage
    }
}

