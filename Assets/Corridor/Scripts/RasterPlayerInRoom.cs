using System.Collections;
using UnityEngine;

public class RasterPlayerInRoom : MonoBehaviour
{
    [SerializeField] private TestRoom testRoom;
    [SerializeField] private float time;
    [SerializeField] private Transform parentInternal;
    [SerializeField] private PlayerCharacterController player;

    private bool raster = false;

    public void StartFollowPlayer() 
    {
        raster = true;
        player.transform.SetParent(parentInternal);
        StartCoroutine(FollowPlayer());
    }

    public void StopFollowPlayer() 
    { 
        raster = false;
        StopAllCoroutines();
    }

    private IEnumerator FollowPlayer()
    {
        var wait = new WaitForSeconds(time);
        while (raster)
        {
            var raster = new Raster
            {
                x = player.transform.localPosition.x,
                y = player.transform.localPosition.z,
                rotation = player.transform.rotation.eulerAngles.y
            };
            GlobalStats.playerSaveStats.AddRaster(testRoom, raster);
            yield return wait;
        }
    }
}
