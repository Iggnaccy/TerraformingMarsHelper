using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class NewGamePrep : MonoBehaviour
{
    [SerializeField] private ResourceGroupSO thisCompany, usedGroup;
    [SerializeField] private Toggle advancedToggle;

    private Button myButton;

    private void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        PlayerPrefs.DeleteAll();
        usedGroup.SetValuesFromOther(thisCompany, advancedToggle.isOn ? 0 : 1);
        SceneManager.LoadScene(1);
    }
}
