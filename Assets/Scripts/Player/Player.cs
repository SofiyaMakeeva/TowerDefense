using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Portal _portal;
    [SerializeField] private int _money;
    [SerializeField] private Spawner _spawner;

    private float _healthInStart;
    private int _moneyInStart;

    public static Player Gamer;

    public float Health => _health;
    public int Money => _money;

    public event UnityAction HealthChanged;
    public event UnityAction<int> MoneyChanged;
    public event UnityAction GameOver;

    private void Awake()
    {
        if (Gamer != null)
        {
            return;
        }

        Gamer = this;
    }

    private void OnEnable()
    {
        _portal.ReachedThePortal += TakeAwayHealth;
        _spawner.EnemySpawned += AddEnemy;
    }

    private void OnDisable()
    {
        _portal.ReachedThePortal -= TakeAwayHealth;
        _spawner.EnemySpawned -= AddEnemy;
    }

    private void Start()
    { 
        _healthInStart = _health;
        _moneyInStart = _money;
        HealthChanged?.Invoke();
        MoneyChanged?.Invoke(_money);
    }
    
    private void AddEnemy(Enemy enemy)
    {
        enemy.Died += TakeReward;
    }

    private void TakeAwayHealth(float damage)
    {
        _health -= damage;
        HealthChanged?.Invoke();

        if (_health <= 0)
        {
            GameOver?.Invoke();
        }
    }

    public void ResetData()
    {
        _health = _healthInStart;
        _money = _moneyInStart;
        HealthChanged?.Invoke();
        MoneyChanged?.Invoke(_money);
    }

    private void TakeReward(Enemy enemy)
    {
        _money += enemy.Reward;
        MoneyChanged?.Invoke(_money);
        enemy.Died -= TakeReward;
    }

    public void ChangeMoneyValue(int value)
    {
        _money += value;
        MoneyChanged?.Invoke(_money);
    }
}
