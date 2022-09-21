using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    private bool _isLastEnemy = false;
    private Player _player;
    private GameOverScreen _gameOverScreen;

    public float Damage => _damage;
    public float Speed => _speed;
    public bool IslastEnemy => _isLastEnemy;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _gameOverScreen = FindObjectOfType<GameOverScreen>();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            _player.ChangeMoneyValue(_reward);

            if (_isLastEnemy == true)
            {
                _gameOverScreen.Open();
            }

            Destroy(gameObject);
        }
    }

    public void OnLastEnemySpawn()
    {
        _isLastEnemy = true;
    }
}
