using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerTextUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private int _idInstruction;
    private void Start()
    {
        text.text = Instructions.instance.GetInstruction(_idInstruction);
        Instructions.instance.changeLanguage += ChangeText;
    }

    private void ChangeText()
    {
        text.text = Instructions.instance.GetInstruction(_idInstruction);
    }
}
