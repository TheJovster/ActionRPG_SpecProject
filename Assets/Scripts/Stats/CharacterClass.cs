using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Stats
{
    [Serializable]
    public class CharacterClass
    {
        public ClassName ClassName;
        public List<Stat> Stats = new List<Stat>();
        public List<DerivedAttributes> DerivedAttributeList = new List<DerivedAttributes>();
        public CharacterExperience CharacterExperience;

        public UnityEvent OnCharacterLevelUp;
        public UnityEvent OnCharacterTakeDamage;
        public UnityEvent OnCharacterHeal;

        //indices - these are left public in case
        private int StrengthIndex = 0;
        private int VitalityIndex = 1;
        private int DexterityIndex = 2;
        private int MagicIndex = 3;
        
        //derived attributes
        private int HealthIndex = 0;
        private int ManaIndex = 1;
        private int DamageIndex = 2;
        
        public void RecalculateDerivedAttributes()
        {
            foreach (var derivedAttribute in DerivedAttributeList)
            {
                switch (derivedAttribute.DerivedAttributeType)
                {
                    case DerivedAttributeType.Health:
                        derivedAttribute.DerivedAttributeMaxValue =
                            derivedAttribute.DerivedAttributeBaseValue +
                            Stats[VitalityIndex].CurrentValue * derivedAttribute.PerStatModifier;
                            derivedAttribute.DerivedAttributeCurrentValue = derivedAttribute.DerivedAttributeMaxValue;
                        break;
                    case DerivedAttributeType.Mana:
                        derivedAttribute.DerivedAttributeMaxValue =
                            derivedAttribute.DerivedAttributeBaseValue +
                            Stats[MagicIndex].CurrentValue * derivedAttribute.PerStatModifier;   
                            derivedAttribute.DerivedAttributeCurrentValue = derivedAttribute.DerivedAttributeMaxValue;
                        break;
                        case DerivedAttributeType.BaseDamage:
                        if (ClassName == ClassName.Warrior)
                        {
                                derivedAttribute.DerivedAttributeMaxValue =
                                derivedAttribute.DerivedAttributeBaseValue +
                                Stats[StrengthIndex].CurrentValue * derivedAttribute.PerStatModifier;
                                derivedAttribute.DerivedAttributeCurrentValue = derivedAttribute.DerivedAttributeMaxValue;
                        }

                        if (ClassName == ClassName.Assassin)
                        {
                                derivedAttribute.DerivedAttributeMaxValue =
                                derivedAttribute.DerivedAttributeBaseValue +
                                Stats[DexterityIndex].CurrentValue * derivedAttribute.PerStatModifier;   
                                derivedAttribute.DerivedAttributeCurrentValue = derivedAttribute.DerivedAttributeMaxValue;
                        }

                        if (ClassName == ClassName.Sorcerer)
                        {
                                derivedAttribute.DerivedAttributeMaxValue =
                                derivedAttribute.DerivedAttributeBaseValue +
                                Stats[MagicIndex].CurrentValue * derivedAttribute.PerStatModifier;   
                                derivedAttribute.DerivedAttributeCurrentValue = derivedAttribute.DerivedAttributeMaxValue;
                        }

                        //TODO: Make a better system for calculating damage
                        break;
                }
            }

        }

        public void TakeDamage(int damage)
        {
            DerivedAttributeList[0].DerivedAttributeCurrentValue -= damage;
            OnCharacterTakeDamage.Invoke();
        }

        public void HealCharacter(int amountToHeal)
        {
            if (DerivedAttributeList[HealthIndex].DerivedAttributeCurrentValue <
                DerivedAttributeList[HealthIndex].DerivedAttributeMaxValue)
            {
                DerivedAttributeList[HealthIndex].DerivedAttributeCurrentValue += amountToHeal;
                if (Mathf.RoundToInt(DerivedAttributeList[HealthIndex].DerivedAttributeCurrentValue) ==
                    Mathf.RoundToInt(DerivedAttributeList[HealthIndex].DerivedAttributeMaxValue))
                {
                    DerivedAttributeList[HealthIndex].DerivedAttributeCurrentValue = 
                        DerivedAttributeList[HealthIndex].DerivedAttributeMaxValue;
                }
            }
            OnCharacterHeal.Invoke();
        }
    }
    
    

    [Serializable]
    public enum ClassName
    {
        Warrior, 
        Assassin,
        Sorcerer
    }
}

