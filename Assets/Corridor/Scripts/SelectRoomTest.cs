using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRoomTest : MonoBehaviour
{
    public GameObject[] testRooms;
    public PlayerCharacterController player;
    void Start()
    {
        if (Random.Range(0, 2) >= 1)
        {
            testRooms[0].SetActive(true);
            GlobalStats.playerSaveStats.RoomAgent = "A";
        }else
            testRooms[1].SetActive(true);
            GlobalStats.playerSaveStats.RoomAgent = "B";
    }
}
