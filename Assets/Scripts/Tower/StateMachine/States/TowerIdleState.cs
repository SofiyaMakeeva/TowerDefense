using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerIdleState : State
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (Target != null)
            {
                return;
            }

            Target = enemy;
        }
    }
}
