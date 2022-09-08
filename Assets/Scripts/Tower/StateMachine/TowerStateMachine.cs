using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tower))]
public class TowerStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private Collider _collider;
    private Enemy _target;
    private State _currentState;
    private State _nextState;

    public State CurrentState => _currentState;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        //_target = GetComponent<Tower>().Enemy;
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
        {
            return;
        }

        _nextState = _currentState.GetNextState();

        if (_nextState != null)
        {
            Transit(_nextState);
        }
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
        {
            //_currentState.Enter(_target);
            _currentState.Enter(_collider);
        }
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;

        if (_currentState != null)
        {
            //_currentState.Enter(_target);
            _currentState.Enter(_collider);
        }
    }
}
