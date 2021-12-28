using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "SO/Player")]
public class PlayerSO : ScriptableObject
{
    [SerializeField] private IntValue maxHp;
    public int MaxHp
    {
        get => maxHp;
        set
        {
            maxHp.SetValue(value);
        }
    }

    [SerializeField] private IntValue currentHp;

    public int CurrentHp
    {
        get => currentHp;
        set
        {
            currentHp.SetValue(Mathf.Clamp(value, 0, maxHp));
        }
    }

    [SerializeField] private IntValue maxMana;
    public int MaxMana
    {
        get => maxMana;
        set
        {
            maxMana.SetValue(value);
        }
    }

    [SerializeField] private IntValue currentMana;

    public int CurrentMana
    {
        get => currentMana;
        set
        {
            currentMana.SetValue(Mathf.Clamp(value, 0, maxMana));
        }
    }

    [SerializeField] private IntValue gold;

    public int Gold
    {
        get => gold;
        set
        {
            gold.SetValue(value);
        }
    }
}
