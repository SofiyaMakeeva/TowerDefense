using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected Enemy Target { get; set; }
    protected Collider Collider { get; private set; }

    public State TargetState => _targetState;

    public bool NeedTransit { get; protected set; }

    //public void Init(Enemy target)
    //{
    //    Target = target;
    //}

    public void Init(Collider collider)
    {
        Collider = collider;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
