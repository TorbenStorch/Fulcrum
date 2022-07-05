using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerColliderEvent : MonoBehaviour
{

    [SerializeField] private GameObject target;
    public UnityEvent inTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            inTrigger.Invoke();
        }
    }
}
