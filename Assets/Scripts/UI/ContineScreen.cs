using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContineScreen : Screen
{
    public override void Close()
    {
        CanvasGroup.alpha = 0;
        CanvasGroup.interactable = false;
        CanvasGroup.blocksRaycasts = false;
        Time.timeScale = 1;
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        CanvasGroup.interactable = true;
        CanvasGroup.blocksRaycasts = true;
        Time.timeScale = 0;
    }

    protected override void OnEXitButtonClick()
    {
        Application.Quit();
    }

    protected override void OnPlayButtonClick()
    {
        Close();
    }
}
