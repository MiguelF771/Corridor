using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDownConfig : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown dropdown;

    private void Awake()
    {
        switch (Instructions.instance.language)
        {
            case Languages.English:
                dropdown.value = 0;
                break;
            case Languages.Spanish:
                dropdown.value = 1;
                break;
        }
    }
}
