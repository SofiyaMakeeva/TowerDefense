using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected GameObject Target { get; set; }

    public State TargetState => _targetState;

    public bool NeedTransit { get; protected set; }

    public void Init(GameObject target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
