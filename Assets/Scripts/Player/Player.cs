using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Portal _portal;
    [SerializeField] private int _money;

    private float _healthInStart;
    private int _moneyInStart;

    public float Health => _health;

    public event UnityAction<float> HealthChanged;
    public event UnityAction<int> MoneyChanged;
    public event UnityAction GameOver;

    public int Money => _money;

    private void OnEnable()
    {
        _portal.ReachedThePortal += TakeAwayHealth;
    }

    private void OnDisable()
    {
        _portal.ReachedThePortal -= TakeAwayHealth;
    }

    private void Start()
    {
        MoneyChanged?.Invoke(_money);
        _healthInStart = _health;
        _moneyInStart = _money;
    }

    public void ChangeMoneyValue(int value)
    {
        _money += value;
        MoneyChanged?.Invoke(_money);
    }

    public void ResetPlayer()
    {
        _health = _healthInStart;
        _money = _moneyInStart;
        HealthChanged?.Invoke(_health);
        MoneyChanged?.Invoke(_money);
    }

    private void TakeAwayHealth(float damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
        {
            GameOver?.Invoke();
        }
    }
}
