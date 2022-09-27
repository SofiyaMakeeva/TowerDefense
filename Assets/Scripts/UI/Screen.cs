using UnityEngine;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup CanvasGroup;
    [SerializeField] protected Button PlayButton;
    [SerializeField] protected Button ExitButton;

    private void OnEnable()
    {
        PlayButton.onClick.AddListener(OnPlayButtonClick);
        ExitButton.onClick.AddListener(OnEXitButtonClick);
    }

    private void OnDisable()
    {
        PlayButton.onClick.RemoveListener(OnPlayButtonClick);
        ExitButton.onClick.RemoveListener(OnEXitButtonClick);
    }

    protected abstract void OnPlayButtonClick();

    protected abstract void OnEXitButtonClick();

    public abstract void Open();

    public abstract void Close();
}
