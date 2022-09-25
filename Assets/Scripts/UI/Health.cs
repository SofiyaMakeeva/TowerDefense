using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _health;
    [SerializeField] private Player _player;

    private float _duration = 5;

    private void Awake()
    {
        _health.maxValue = _player.Health;
        _health.value = _player.Health;
        _health.minValue = 0;
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged()
    {
        StartCoroutine(ChangeHealthUI());
    }

    private IEnumerator ChangeHealthUI()
    {
        while (_player.Health != _health.value)
        {
            _health.value = Mathf.MoveTowards(_health.value, _player.Health, _duration * Time.deltaTime);

            yield return null;
        }
    }
}
