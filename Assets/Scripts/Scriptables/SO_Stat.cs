using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Diablo/Stat", fileName = "Stat")]
public class SO_Stat : ScriptableObject
{
    public string StatName;
    public float MinValue;
    public float BaseMaxValue;

    public float BaseValue;

    public UnityEvent<float> OnValueChanged = new UnityEvent<float>();

    public void Awake()
    {
        
    }

    public void Modify(float change)
    {
        BaseValue += change;
        BaseValue = Mathf.Clamp(BaseValue, MinValue, BaseMaxValue);

        OnValueChanged.Invoke(BaseValue);
    }
}