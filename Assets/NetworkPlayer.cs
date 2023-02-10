using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;
    private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        XROrigin xrOrigin = FindObjectOfType<XROrigin>();
        headRig = xrOrigin.transform.Find("Camera Offset/Main Camera");
        leftHandRig = xrOrigin.transform.Find("Camera Offset/LeftHand Controller");
        rightHandRig = xrOrigin.transform.Find("Camera Offset/RightHand Controller");
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
        MapPosition(head, headRig); 
        MapPosition(leftHand, leftHandRig); 
        MapPosition(rightHand, rightHandRig); 
        
    }
    

    void MapPosition(Transform target, Transform rigTransform)
    {
        // InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
        // InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);

        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }
}

