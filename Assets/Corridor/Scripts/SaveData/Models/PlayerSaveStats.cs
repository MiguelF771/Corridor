using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class GlobalStats
{
    public static PlayerSaveStats playerSaveStats = new PlayerSaveStats();
}

[System.Serializable]
public class PlayerSaveStats
{
    public UserData userData;
    public List<Raster> testRoomA;
    public List<Raster> testRoomB;

    public void SetUser(UserData user)
    {
        if (userData == null)
            userData = user;
#if UNITY_EDITOR
        Debug.Log(user.Name + " registrado");
#endif
    }

}
[System.Serializable]
public struct Raster
{
    public Vector2 position;
    public float rotation;
    public Time time;
}
