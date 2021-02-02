using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayAction : MonoBehaviour
{
    public float _seconds;
    public UnityEvent _action;

    public void StartWait()
    {
        StartCoroutine(Wait());
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(_seconds);
        _action?.Invoke();
    }
}
