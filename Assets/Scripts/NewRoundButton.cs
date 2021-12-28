using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class NewRoundButton : MonoBehaviour
{
    [SerializeField] List<ResourceSO> resources;
    [SerializeField] Button newRoundButton, undoButton;
    [SerializeField] ResourceSO energy, heat;
    [SerializeField] IntValue roundCount;
    [SerializeField] ScriptableObjectsAsSaves saves;

    public void NewRoundOnClick()
    {
        saves.CreateSave($"Round{roundCount}/");
        heat.Transfer(energy);
        foreach(var r in resources)
        {
            r.Calculate();
        }
        roundCount.SetValue(roundCount + 1);
        saves.CreateSave($"Round{roundCount}/");
    }

    public void UndoOnClick()
    {
        saves.LoadSave($"Round{roundCount-1}/");
    }

    private void OnValidate()
    {
        if (!newRoundButton) newRoundButton = GetComponent<Button>();
    }

    private void Start()
    {
        newRoundButton.onClick.AddListener(NewRoundOnClick);
        undoButton.onClick.AddListener(UndoOnClick);
    }
}
