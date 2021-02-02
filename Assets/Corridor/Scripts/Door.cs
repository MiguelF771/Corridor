using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform _door1;
    [SerializeField] private Transform _door2;
    [SerializeField] [Range(0f, 1f)] private float _time;
    [SerializeField] bool _isOpen;
    [SerializeField] bool _disableEnd;

    private IEnumerator OpenAnCloseDoorCorutine(Transform door,float time)
    {
        var startPosition = door.localPosition;
        var endPosition = (_isOpen)? startPosition / 3: startPosition * 3;
        var pos = 0f;
        while (pos <= 1)
        {
            door.localPosition = Vector3.Lerp(startPosition, endPosition,pos);
            pos += .01f;
            yield return new WaitForSeconds(time);
        }
        gameObject.SetActive(!_disableEnd);
    }

    public void OpenDoor()
    {
        if (!_isOpen)
        {
            StartCoroutine(OpenAnCloseDoorCorutine(_door1, _time));
            StartCoroutine(OpenAnCloseDoorCorutine(_door2, _time));
            _isOpen = true;
        }
    }

    public void CloseDoor()
    {
        if (_isOpen)
        {
            StartCoroutine(OpenAnCloseDoorCorutine(_door1, _time));
            StartCoroutine(OpenAnCloseDoorCorutine(_door2, _time));
            _isOpen = false;
        }
    }
}
