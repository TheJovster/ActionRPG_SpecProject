using System;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace Stats
{
    [Serializable]
    public class CharacterClass
    {
        public ClassName ClassName;
        public List<Stat> Stats = new List<Stat>();
        public List<DerivedAttributes> DerivedAttributeList = new List<DerivedAttributes>();
        public CharacterExperience CharacterExperience;

        //indices - these are left public in case
        private int StrengthIndex = 0;
        private int VitalityIndex = 1;
        private int DexterityIndex = 2;
        private int MagicIndex = 3;
        
        public void RecalculateDerivedAttributes()
        {
            foreach (var derivedAttribute in DerivedAttributeList)
            {
                switch (derivedAttribute.DerivedAttributeType)
                {
                    case DerivedAttributeType.Health:
                        derivedAttribute.DerivedAttributeCurrentValue =
                            derivedAttribute.DerivedAttributeBaseValue +
                            Stats[VitalityIndex].CurrentValue * derivedAttribute.PerStatModifier;                            
                        break;
                    case DerivedAttributeType.Mana:
                        derivedAttribute.DerivedAttributeCurrentValue =
                            derivedAttribute.DerivedAttributeBaseValue +
                            Stats[MagicIndex].CurrentValue * derivedAttribute.PerStatModifier;   
                        break;
                        case DerivedAttributeType.BaseDamage:
                        if (ClassName == ClassName.Warrior)
                        {
                            derivedAttribute.DerivedAttributeCurrentValue =
                                derivedAttribute.DerivedAttributeBaseValue +
                                Stats[StrengthIndex].CurrentValue * derivedAttribute.PerStatModifier;  
                        }

                        if (ClassName == ClassName.Assassin)
                        {
                            derivedAttribute.DerivedAttributeCurrentValue =
                                derivedAttribute.DerivedAttributeBaseValue +
                                Stats[DexterityIndex].CurrentValue * derivedAttribute.PerStatModifier;   
                        }

                        if (ClassName == ClassName.Sorcerer)
                        {
                            derivedAttribute.DerivedAttributeCurrentValue =
                                derivedAttribute.DerivedAttributeBaseValue +
                                Stats[MagicIndex].CurrentValue * derivedAttribute.PerStatModifier;   
                        }

                        //TODO: Make a better system for calculating damage
                        break;
                }
            }

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

