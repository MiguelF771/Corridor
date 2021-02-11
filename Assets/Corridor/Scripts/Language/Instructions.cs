using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[CreateAssetMenu(fileName = "Instructions")]
public class Instructions : ScriptableObject
{
    public static Instructions instance;

    public Action changeLanguage;
    public Languages language;
    [SerializeField]
    private TextInstruction[] _instructions;

    public Instructions()
    {
        if (instance == null)
            instance = this;
    }

    public string GetInstruction(int id)
    {
        switch (language)
        {
            case Languages.English:
                return _instructions[id].English;
            case Languages.Spanish:
                return _instructions[id].Spanish;
        }

        throw new IndexOutOfRangeException();
    }

    public void ChangeLanguage(int index)
    {
        if (index == 0)
            language = Languages.English;
        else if(index == 1)
            language = Languages.Spanish;

        changeLanguage?.Invoke();
    }
}

[System.Serializable]
public struct TextInstruction
{
    public string English;
    public string Spanish;
}

public enum Languages
{
    English = 0,
    Spanish = 1
}