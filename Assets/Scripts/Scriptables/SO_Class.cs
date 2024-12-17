using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Diablo/Class", fileName = "Class")]
public class SO_Class: ScriptableObject
{
    public string ClassName;

    public List<SO_Stat> Stats;
}