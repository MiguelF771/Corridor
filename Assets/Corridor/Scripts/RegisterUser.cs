using System;
using System.IO;
using System.Net;
using TMPro;
using UnityEngine;

public class RegisterUser : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField[] inputs;
    public AlertsInUI alertsInUI;
    public GameObject instruct;
    public void RegisterPlayer()
    {
        if (ValidateData())
        {
            var user = new UserData(inputs[0].text,
                                    Convert.ToInt32(inputs[1].text),
                                    inputs[2].text,
                                    inputs[3].text);

            GlobalStats.playerSaveStats.SetUser(user);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            instruct.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            alertsInUI.ShowAlert(Instructions.instance.GetInstruction(6), 3);
        }
    }
    public bool ValidateData()
    {
        foreach (var item in inputs)
        {
            if (item.text == "" || item.text == null)
                return false;
        }

        if (int.TryParse(inputs[1].text, out var age))
            return true;

        return false;
    }
}