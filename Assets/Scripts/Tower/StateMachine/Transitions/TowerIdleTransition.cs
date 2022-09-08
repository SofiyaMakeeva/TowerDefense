using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerIdleTransition : Transition
{
    //[SerializeField] private float _transitionRange;
    //[SerializeField] private float _rangeSpread;

    //private void Start()
    //{
    //    _transitionRange += Random.Range(-_rangeSpread, _rangeSpread);
    //}

    private void Update()
    {
        if (Target != null)
        {
            NeedTransit = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            Target = enemy;
            NeedTransit = true;
        }
    }
}
