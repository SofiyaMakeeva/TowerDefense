using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TowerAttackState : State
{
    [SerializeField] private float _fireRate = 1;

    private float _fireCountdown = 0;

    private void Update()
    {
        if (_fireCountdown <= 0)
        {
            Shoot();
            _fireCountdown = 1f / _fireRate;
        }

        _fireCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        Debug.Log("Shoot");
    }
}
