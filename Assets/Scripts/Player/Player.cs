using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Portal _portal;

    public float Health => _health;

    public event UnityAction<float> HealthChanged;

    public int Money { get; private set; }

    private void OnEnable()
    {
        _portal.ReachedThePortal += TakeAwayHealth;
    }

    private void OnDisable()
    {
        _portal.ReachedThePortal -= TakeAwayHealth;
    }

    public void AddMoney(int reward)
    {
        Money += reward;
    }

    private void TakeAwayHealth(float damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);
    }
}
