using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class GlobalStats
{
    public static PlayerSaveStats playerSaveStats = new PlayerSaveStats();
}

public enum TestRoom { A, B }

[System.Serializable]
public class PlayerSaveStats
{
    public UserData userData;
    public List<Raster> testRoomA = new List<Raster>();
    public List<Raster> testRoomB = new List<Raster>();

    public void SetUser(UserData user)
    {
        if (userData == null)
            userData = user;
#if UNITY_EDITOR
        Debug.Log(user.Name + " registrado");
#endif
    }

    public void AddRaster(TestRoom testRoom, Raster raster)
    {
        switch (testRoom)
        {
            case TestRoom.A:
                testRoomA.Add(raster);
                break;
            case TestRoom.B:
                testRoomB.Add(raster);
                break;
        }
    }

}
[System.Serializable]
public struct Raster
{
    public float x;
    public float y;
    public float rotation;
}
