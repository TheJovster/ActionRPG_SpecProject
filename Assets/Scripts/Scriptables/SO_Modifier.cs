using UnityEngine;

[CreateAssetMenu(menuName = "Diablo/Modifier", fileName = "Modifier")]
public class SO_Modifier : ScriptableObject
{
    public string ModifierName;
    public SO_Stat AffectedStat;
    public float ValueChange;
    public float MaxValueChange;

    public float Duration; //0 = Not Time-Based

    private float timePassed;

    public bool HasExpired(float time)
    {
        if (Duration == 0) return false;

        timePassed += time;

        if (timePassed < Duration)
        {
            return false;
        }

        return true;
    }
}