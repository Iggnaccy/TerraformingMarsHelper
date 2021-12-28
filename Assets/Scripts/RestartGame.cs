using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RestartGame : MonoBehaviour
{
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
        PlayerPrefs.DeleteAll();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    private IEnumerator WaitForSecondClick()
    {
        yield return new WaitForSeconds(1.5f);
        if (clickCount > 0) clickCount = 0;
    }
}
