using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlertsInUI : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void ShowAlert(string message,float time)
    {
        gameObject.SetActive(true);
        text.text = message;
        text.color = Color.red;
        StartCoroutine(DisableTime(time));
    }

    private IEnumerator DisableTime(float time)
    {
        var wait = new WaitForSeconds(time);
        yield return wait;
        gameObject.SetActive(false);
    }
}
