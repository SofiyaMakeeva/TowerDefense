using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tower))]
public class TowerStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private GameObject _target;
    private State _currentState;
    private State _nextState;
    private Tower _tower;

    public State CurrentState => _currentState;

    private void Awake()
    {
        _tower = GetComponent<Tower>();
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
            _currentState.Enter(_target);
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
            _currentState.Enter(_target);
        }
    }
}
