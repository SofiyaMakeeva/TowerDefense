using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Transform _path;

    private Wave _currentWave;
    private int _currentWaveNumber = -1;
    private int _spawned;
    private Enemy _enemy;
    private WaitForSeconds _waitForSeconds;
    private Coroutine _spawnEnemy;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<Enemy> EnemySpawned;

    private void Update()
    {
        if (_currentWave == null)
        {
            return;
        }

        if (_currentWave.Count <= _spawned)
        {
            if (_spawnEnemy != null)
            {
                StopCoroutine(_spawnEnemy);
            }

            if (_waves.Count > _currentWaveNumber + 1)
            {
                AllEnemySpawned?.Invoke();
            }
            else if (_waves.Count == _currentWaveNumber + 1 && _currentWave.Count == _spawned)
            {
                if (_enemy.IslastEnemy == false)
                {
                    _enemy.OnLastEnemySpawn();
                } 
            }
        }
    }

    private IEnumerator CountDownTheTime()
    {
        while (_currentWave.Count > _spawned)
        {
            InstantiateEnemy();
            _spawned++;

            yield return _waitForSeconds;
        }
    }

    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0;
        _spawnEnemy = StartCoroutine(CountDownTheTime());
    }

    private void InstantiateEnemy()
    {
        _enemy = Instantiate(_currentWave.Template, _spawnPosition.position, _spawnPosition.rotation, _spawnPosition).GetComponent<Enemy>();
        EnemySpawned?.Invoke(_enemy);
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        _waitForSeconds = new WaitForSeconds(_currentWave.Delay);
    }
}

[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;
}
