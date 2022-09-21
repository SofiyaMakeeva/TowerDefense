using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup CanvasGroup;
    [SerializeField] protected Button PlayButton;
    [SerializeField] protected Button AudioButton;
    [SerializeField] protected Button ExitButton;

    private void OnEnable()
    {
        PlayButton.onClick.AddListener(OnPlayButtonClick);
        AudioButton.onClick.AddListener(OnAudioButtonClick);
        ExitButton.onClick.AddListener(OnEXitButtonClick);
    }

    private void OnDisable()
    {
        PlayButton.onClick.RemoveListener(OnPlayButtonClick);
        AudioButton.onClick.RemoveListener(OnAudioButtonClick);
        ExitButton.onClick.RemoveListener(OnEXitButtonClick);
    }

    protected abstract void OnPlayButtonClick();

    protected abstract void OnAudioButtonClick();

    protected abstract void OnEXitButtonClick();

    public abstract void Open();

    public abstract void Close();
}
