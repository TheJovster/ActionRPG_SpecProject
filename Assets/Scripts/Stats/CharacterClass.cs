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
        
        public void RecalculateDerivedAttributes()
        {
            foreach (var derivedAttribute in DerivedAttributeList)
            {
                switch (derivedAttribute.DerivedAttributeType)
                {
                    case DerivedAttributeType.Health:
                        derivedAttribute.DerivedAttributeCurrentValue =
                            derivedAttribute.DerivedAttributeBaseValue +
                            Stats[1].CurrentValue * derivedAttribute.PerStatModifier;                            
                        break;
                    case DerivedAttributeType.Mana:
                        derivedAttribute.DerivedAttributeCurrentValue =
                            derivedAttribute.DerivedAttributeBaseValue +
                            Stats[3].CurrentValue * derivedAttribute.PerStatModifier;   
                        break;
                    case DerivedAttributeType.BaseDamage:
                        derivedAttribute.DerivedAttributeCurrentValue =
                            derivedAttribute.DerivedAttributeBaseValue +
                            Stats[0].CurrentValue * derivedAttribute.PerStatModifier;   
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

