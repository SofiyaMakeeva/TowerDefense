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
    private float _timeAfterLastSpawn;
    private int _spawned;
    private Enemy _enemy;

    public event UnityAction AllEnemySpawned;

    private void Update()
    {
        if (_currentWave == null)
        {
            return;
        }

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
        }

        if (_currentWave.Count <= _spawned)
        {
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

            _currentWave = null;
        }
    }

    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0;
    }

    private void InstantiateEnemy()
    {
        _enemy = Instantiate(_currentWave.Template, _spawnPosition.position, _spawnPosition.rotation, _spawnPosition).GetComponent<Enemy>();
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }
}

[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;
}
