using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverScreen : Screen
{
    public event UnityAction RestartButtonClick;

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        CanvasGroup.interactable = false;
        CanvasGroup.blocksRaycasts = false;
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        CanvasGroup.interactable = true;
        CanvasGroup.blocksRaycasts = true;
    }

    protected override void OnAudioButtonClick()
    {
        Debug.Log("Audio will be soon");
    }

    protected override void OnEXitButtonClick()
    {
        Application.Quit();
    }

    protected override void OnPlayButtonClick()
    {
        RestartButtonClick?.Invoke();
    }
}
