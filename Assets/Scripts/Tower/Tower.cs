using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Tower : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Collider _collider;

    public Enemy Enemy => _enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (_enemy != null)
            {
                return;
            }

            _enemy = enemy;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _enemy = null;
    }
}
