using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class ContinueGameButton : MonoBehaviour
{
    private Button myButton;

    private void Start()
    {
        myButton = GetComponent<Button>();
        myButton.interactable = CheckForExistingGame();
        myButton.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        if(CheckForExistingGame())
        {
            SceneManager.LoadScene(1);
        }
    }

    private void OnEnable()
    {
        if(myButton)
            myButton.interactable = CheckForExistingGame();
    }

    public bool CheckForExistingGame()
    {
        if (PlayerPrefs.HasKey("RoundCounter"))
        {
            return true;
        }
        else Debug.Log("There is no save, disabling continue button");
        return false;
    }
}
