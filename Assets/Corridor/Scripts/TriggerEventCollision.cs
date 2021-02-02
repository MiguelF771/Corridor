using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventCollision : MonoBehaviour
{
    [SerializeField] private UnityEvent _enter;
    [SerializeField] private UnityEvent _exit;

    private void OnTriggerEnter(Collider other)
    {
        _enter?.Invoke();
    }


    private void OnTriggerExit(Collider other)
    {
        _exit?.Invoke();
    }
}
