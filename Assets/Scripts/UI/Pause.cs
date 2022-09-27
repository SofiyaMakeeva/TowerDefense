using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private ContineScreen _contineScreen;

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _contineScreen.Open();
    }
}
