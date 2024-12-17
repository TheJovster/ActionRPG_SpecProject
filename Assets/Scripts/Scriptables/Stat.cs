using UnityEngine;

//Stat scriptable object, holds values for stat values used by a player class
namespace Scriptables
{
    [CreateAssetMenu(fileName = "Stat", menuName = "DiabloPlus/Stat")]
    public class Stat : ScriptableObject
    {
        public string StatName;
        public float StatBaseValue;
        public float StatMinValue;
    }
}
