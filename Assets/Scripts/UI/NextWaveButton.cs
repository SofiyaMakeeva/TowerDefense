using UnityEngine;
using UnityEngine.UI;

public class NextWaveButton : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _nextWaveButton;

    private void OnEnable()
    {
        _spawner.AllEnemySpawned += OnAllEnemySpawned;
        _nextWaveButton.onClick.AddListener(OnNextButtonClick);
    }

    private void OnDisable()
    {
        _spawner.AllEnemySpawned -= OnAllEnemySpawned;
        _nextWaveButton.onClick.RemoveListener(OnNextButtonClick);
    }

    private void OnAllEnemySpawned()
    {
        _nextWaveButton.gameObject.SetActive(true);
    }

    private void OnNextButtonClick()
    {
        _spawner.NextWave();
        _nextWaveButton.gameObject.SetActive(false);
    }
}
