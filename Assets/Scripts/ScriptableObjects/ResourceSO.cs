using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "SO/Resource")]
public class ResourceSO : ScriptableObject
{
    [SerializeField] private IntValue current, income;
    [SerializeField] private IntValue terraform;

    public void Calculate()
    {
        if(terraform != null)
            current.SetValue(current + income + terraform);
        else current.SetValue(current + income);
    }

    public void Transfer(ResourceSO other)
    {
        current.SetValue(current + other.current);
        other.current.SetValue(0);
    }

    public void SetValueFromOther(ResourceSO other, int incomeBoost = 0)
    {
        current.debug = true;
        current.SetValue(other.current);
        current.debug = false;
        income.debug = true;
        income.SetValue(other.income + incomeBoost);
        income.debug = false;
    }

    public void ForceSave()
    {
        current.Save();
        income.Save();
    }
}
