using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackTransition : Transition
{
    //private void Update()
    //{
    //    if (Target == null)
    //    {
    //        NeedTransit = true;
    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        Target = null;
        NeedTransit = true;
    }
}
