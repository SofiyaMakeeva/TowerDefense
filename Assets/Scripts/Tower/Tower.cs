using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Tower : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private Transform _partToRotate;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _fireRate = 1;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private int _price;

    private Animator _animator;
    private Transform _target;
    private GameObject[] _enemies;
    private string _enemyTag = "Enemy";
    private float _distanceToEnemy;
    private float _shotestDistance;
    private GameObject _nearestEnemy;
    private Vector3 _direction;
    private Vector3 _rotation;
    private Quaternion _lookRotation;
    private float _fireCountDown = 0;

    public int Price => _price;
    public GameObject NearestEnemy => _nearestEnemy;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        InvokeRepeating("UpdateTarget", 0, 0.5f);
    }

    private void Update()
    {
        if (_target == null)
        {
            return;
        }

        _direction = _target.position - transform.position;
        _lookRotation = Quaternion.LookRotation(_direction);
        _rotation = Quaternion.Lerp(_partToRotate.rotation, _lookRotation, _turnSpeed * Time.deltaTime).eulerAngles;
        _partToRotate.rotation = Quaternion.Euler(0, _rotation.y, 0);

        if (_fireCountDown <= 0f)
        {
            _animator.SetTrigger("Attack");
            Shoot();
            _fireCountDown = 1f / _fireRate;
        }

        _fireCountDown -= Time.deltaTime;
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);

        bullet.Seek(_target);    
    }

    private void UpdateTarget()
    {
        _enemies = GameObject.FindGameObjectsWithTag(_enemyTag);
        _shotestDistance = Mathf.Infinity;
        _nearestEnemy = null;

        foreach (var enemy in _enemies)
        {
            _distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (_distanceToEnemy < _shotestDistance)
            {
                _shotestDistance = _distanceToEnemy;
                _nearestEnemy = enemy;
            }
        }

        if (_nearestEnemy != null && _shotestDistance <= _range)
        {
            _target = _nearestEnemy.transform;
            
        }
        else
        {
            _target = null;
        }
    }
}
