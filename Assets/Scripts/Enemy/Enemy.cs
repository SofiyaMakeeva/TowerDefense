using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    private bool _isLastEnemy = false;

    public float Damage => _damage;
    public float Speed => _speed;
    public int Reward => _reward;
    public bool IslastEnemy => _isLastEnemy;

    public event UnityAction<Enemy> Died;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Died?.Invoke(this);

            if (_isLastEnemy == true)
            {
                GameOverScreen.GameOver.Open();
            }

            Destroy(gameObject);
        }
    }

    public void OnLastEnemySpawn()
    {
        _isLastEnemy = true;
    }
}
