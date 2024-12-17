using System;
using System.Collections.Generic;

namespace Stats
{
    [Serializable]
    public class CharacterClass
    {

        public ClassName ClassName;
        public List<Stat> Stats = new List<Stat>();
        public Stat Strength;

    }

    [Serializable]
    public enum ClassName
    {
        Warrior, 
        Assassin,
        Sorcerer
    }
}

