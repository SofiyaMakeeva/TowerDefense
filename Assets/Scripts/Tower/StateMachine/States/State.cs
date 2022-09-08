using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected Enemy Target { get; set; }
    protected Collider Collider { get; set; }

    //public void Enter(Enemy target)
    //{
    //    if (enabled == false)
    //    {
    //        Target = target;
    //        enabled = true;

    //        foreach (var transition in _transitions)
    //        {
    //            transition.enabled = true;
    //            transition.Init(Target);
    //        }
    //    }
    //}

    public void Enter(Collider collider)
    {
        if (enabled == false)
        {
            //Target = collider;
            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Collider);
            }
        }
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }

    public State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.TargetState;
            }
        }

        return null;
    }
}
