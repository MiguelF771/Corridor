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
    public UserData UserData;
    public string RoomAgent;
    public List<Raster> Agent = new List<Raster>();
    public List<Raster> TestRoomA = new List<Raster>();
    public List<Raster> TestRoomB = new List<Raster>();

    public void SetUser(UserData user)
    {
        if (UserData == null)
            UserData = user;
    }

    public void AddRaster(TestRoom testRoom, Raster raster)
    {
        switch (testRoom)
        {
            case TestRoom.A:
                TestRoomA.Add(raster);
                break;
            case TestRoom.B:
                TestRoomB.Add(raster);
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
