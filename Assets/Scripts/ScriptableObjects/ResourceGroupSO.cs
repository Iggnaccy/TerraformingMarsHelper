using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource Group", menuName = "SO/ResourceGroup")]
public class ResourceGroupSO : ScriptableObject
{
    [SerializeField] ResourceSO gold, green, steel, titanium, energy, heat;

    public void SetValuesFromOther(ResourceGroupSO other, int incomeBoost = 0)
    {
        gold.SetValueFromOther(other.gold, incomeBoost);
        green.SetValueFromOther(other.green, incomeBoost);
        steel.SetValueFromOther(other.steel, incomeBoost);
        titanium.SetValueFromOther(other.titanium, incomeBoost);
        energy.SetValueFromOther(other.energy, incomeBoost);
        heat.SetValueFromOther(other.heat, incomeBoost);
    }

    public void ForceSave()
    {
        gold.ForceSave();
        green.ForceSave();
        steel.ForceSave();
        titanium.ForceSave();
        energy.ForceSave();
        heat.ForceSave();
    }
}
