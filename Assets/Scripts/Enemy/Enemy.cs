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
    [SerializeField] private int _experience;

    public float Damage => _damage;
    public int Experience => _experience;
    public float Speed => _speed;
    public int Reward => _reward;

    public event UnityAction<Enemy> Dying;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            //Dying?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
