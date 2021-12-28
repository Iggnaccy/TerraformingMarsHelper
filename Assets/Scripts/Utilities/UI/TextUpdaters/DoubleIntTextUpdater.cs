using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleIntTextUpdater : TextSOUpdater<int>
{
    [SerializeField] IntValue secondValue;

    protected override void Start()
    {
        base.Start();
        secondValue.OnValueChanged.AddListener(OnValueChange);
        text.text = prefix + (value + secondValue).ToString() + suffix;
    }

    protected override void OnValueChange(int newValue)
    {
        text.text = prefix + (value.Value + secondValue.Value).ToString() + suffix;
    }
}
