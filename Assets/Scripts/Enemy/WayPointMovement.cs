using UnityEngine;

public class WayPointMovement : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private Transform _path;
    private Transform[] _points;
    private int _currentPoint = 0;
    private Transform _target;

    private void Start()
    {
        _path = FindObjectOfType<Path>().transform;

        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }
    private void Update()
    {
        if (_currentPoint <= _points.Length)
        {
            _target = _points[_currentPoint];

            transform.position = Vector3.MoveTowards(transform.position, _target.position, _enemy.Speed * Time.deltaTime);
            transform.LookAt(_target.position);

            if (transform.position == _target.position)
            {
                _currentPoint++;
            }
        }
    }
}
