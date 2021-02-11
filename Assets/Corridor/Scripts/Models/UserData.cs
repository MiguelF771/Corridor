using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string Name;
    public int Age;
    public string Gender;
    public string Nationality;

    public UserData(string name, int age, string gender, string nationality)
    {
        Name = name;
        Age = age;
        Gender = gender;
        Nationality = nationality;
    }
}
