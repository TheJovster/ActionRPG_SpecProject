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
            foreach (var DerivedAttribute in DerivedAttributeList)
            {
                switch (DerivedAttribute.DerivedAttributeType)
                {
                    case DerivedAttributeType.Health:
                        DerivedAttribute.DerivedAttributeCurrentValue =
                            DerivedAttribute.DerivedAttributeBaseValue +
                            Stats[1].CurrentValue * DerivedAttribute.PerStatModifier;                            
                        break;
                    case DerivedAttributeType.Mana:
                        DerivedAttribute.DerivedAttributeCurrentValue =
                            DerivedAttribute.DerivedAttributeBaseValue +
                            Stats[3].CurrentValue * DerivedAttribute.PerStatModifier;   
                        break;
                    case DerivedAttributeType.BaseDamage:
                        DerivedAttribute.DerivedAttributeCurrentValue =
                            DerivedAttribute.DerivedAttributeBaseValue +
                            Stats[0].CurrentValue * DerivedAttribute.PerStatModifier;   
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

