using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    //[SerializeField] private ParticleSystem _particleSystem;

    private Transform _target;

    //private void Start()
    //{
    //    _particleSystem.Play();
    //}

    private void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
        }

        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime); 
    }

    public void Seek(Transform target)
    {
        _target = target;
    }

    private void Damage(Enemy enemy)
    {
        if (enemy != null)
        {
            enemy.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            Damage(enemy);
        }
    }
}
