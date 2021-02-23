using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private PlayerCharacterController player;
    public void End()
    {
        player.maxSpeedOnGround = 0;

#if UNITY_WEBGL && !UNITY_EDITOR
        WebGLPlugins.SendJsonWeb(JsonUtility.ToJson(GlobalStats.playerSaveStats));
#endif
    }
}
