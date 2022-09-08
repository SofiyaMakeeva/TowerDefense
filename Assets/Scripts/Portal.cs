using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Portal : MonoBehaviour
{
    public event UnityAction<float> ReachedThePortal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            ReachedThePortal?.Invoke(enemy.Damage);
            Destroy(enemy.gameObject);
        }
    }
}
