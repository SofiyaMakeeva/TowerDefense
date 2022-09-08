using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _health;
    [SerializeField] private Player _player;

    private float _duration = 1;

    private void Awake()
    {
        _health.maxValue = _player.Health;
        _health.value = _player.Health;
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float health)
    {
        StartCoroutine(ChangeHealthUI(health));
    }

    private IEnumerator ChangeHealthUI(float health)
    {
        while (health != _health.value)
        {
            _health.value = Mathf.MoveTowards(_health.value, health, _duration * Time.deltaTime);

            yield return null;
        }
    }
}
