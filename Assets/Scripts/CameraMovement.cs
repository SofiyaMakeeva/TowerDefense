using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;

    private float _height;
    private float _tempHeight;

    private void Start()
    {
        _height = _maxHeight;
        _tempHeight = _height;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, 1 * _speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -1 * _speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1 * _speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(1 * _speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (_height < _maxHeight)
            {
                _tempHeight++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (_height > _minHeight)
            {
                _tempHeight--;
            }
        }

        _tempHeight = Mathf.Clamp(_tempHeight, _minHeight, _maxHeight);
        _height = Mathf.MoveTowards(_height, _tempHeight, _speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, _height, transform.position.z);
    }
}
