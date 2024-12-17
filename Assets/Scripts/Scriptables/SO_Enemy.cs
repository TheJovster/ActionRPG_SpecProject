using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Diablo/Enemy", fileName = "Enemy")]
public class SO_Enemy: ScriptableObject
{
    public string EnemyName;
    public List<SO_Stat> Stats;
}
