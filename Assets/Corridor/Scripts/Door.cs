using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform _door1;
    [SerializeField] private Transform _door2;
    [SerializeField] [Range(0f, 0.1f)] private float _time;
    [SerializeField] bool _isOpen;
    [SerializeField] bool _disableEnd;
    private IEnumerator OpenAnCloseDoorCorutine(Transform door,float time, float moveSpacing)
    {
        var startPosition = door.localPosition;
        var endPosition = new Vector3(startPosition.x,
                                        startPosition.y + moveSpacing,
                                        startPosition.z);
        var pos = 0f;
        while (pos <= 1)
        {
            door.localPosition = Vector3.Lerp(startPosition, endPosition,pos);
            pos += .01f;
            yield return new WaitForSeconds(time);
        }
        gameObject.SetActive(!(_disableEnd && _isOpen));
    }

    public void OpenDoor()
    {
        if (!_isOpen)
        {
            _isOpen = true;
            StartCoroutine(OpenAnCloseDoorCorutine(_door1, _time,3));
            StartCoroutine(OpenAnCloseDoorCorutine(_door2, _time,-3));
        }
    }

    public void CloseDoor()
    {
        gameObject.SetActive(true);
        if (_isOpen)
        {
            _isOpen = false;
            StartCoroutine(OpenAnCloseDoorCorutine(_door1, _time,-3));
            StartCoroutine(OpenAnCloseDoorCorutine(_door2, _time,3));
        }
    }
}
