using UnityEngine;

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
    private Enemy[] _enemies;
    private float _distanceToEnemy;
    private float _shotestDistance;
    private Enemy _nearestEnemy;
    private Vector3 _direction;
    private Vector3 _rotation;
    private Quaternion _lookRotation;
    private float _fireCountDown = 0;
    private string _attackAnimation = "Attack";
    private float _timeForUpdate = 0.5f;

    public int Price => _price;
    public Enemy NearestEnemy => _nearestEnemy;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        InvokeRepeating(nameof(UpdateTarget), 0, _timeForUpdate);
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
            _animator.SetTrigger(_attackAnimation);
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
        _enemies = FindObjectsOfType<Enemy>();
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
