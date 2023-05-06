using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class OrientationCorrection : MonoBehaviour
{
    // public GameObject player;
    public Vector3 spawnPosition;
    // public Vector3 spawnRotation;
    [SerializeField] Transform resetTransform;
    [SerializeField] GameObject player;
    [SerializeField] Camera playerHead;





    
    public void SetPlayerSpawnPosition()
    {
        // player.transform.position = spawnPosition;
        // player.transform.eulerAngles = spawnRotation;
        //rotation stuff
        var rotationAngleY = playerHead.transform.rotation.eulerAngles.y -  resetTransform.rotation.eulerAngles.y;
        player.transform.Rotate(0, -rotationAngleY, 0);

        //position stuff
        var distanceDiff =  resetTransform.position - playerHead.transform.position;
        player.transform.position += distanceDiff;




    }

    // Call this function to trigger the event
    public void OnEventTriggered()
    {
        SetPlayerSpawnPosition();
    }
}
