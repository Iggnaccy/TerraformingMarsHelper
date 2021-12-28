using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RestartGame : MonoBehaviour
{
    [SerializeField] List<IntValue> valuesToReset;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private int clickCount = 0;
    private void OnClick()
    {
        clickCount++;
        if (clickCount > 1)
        {
            ResetGame();
            clickCount = 0;
        }
        else StartCoroutine(WaitForSecondClick());
    }

    private void ResetGame()
    {
        foreach(var value in valuesToReset)
        {
            value.SetValue(value.StartValue);
        }
    }

    private IEnumerator WaitForSecondClick()
    {
        yield return new WaitForSeconds(1.5f);
        if (clickCount > 0) clickCount = 0;
    }
}
