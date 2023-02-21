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
    //public GameObject cubePrefab;


    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (!photonView.IsMine)
    //     {
    //         return;
    //     }

    //     PhotonView otherPhotonView = collision.gameObject.GetComponent<PhotonView>();
    //     if (otherPhotonView != null && otherPhotonView.IsMine)
    //     {
    //         // This is a collision between two networked players.
    //         Vector3 spawnPosition = (transform.position + collision.transform.position) / 2;
    //         PhotonNetwork.Instantiate(cubePrefab.name, spawnPosition, Quaternion.identity);
    //     }
    // }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.name == "Polo")
    //     {
    //         cubePrefab.SetActive(false);   
    //     }
    // }



    // Start is called before the first frame update
    void Start()
    {
        XROrigin xrOrigin = FindObjectOfType<XROrigin>();
        headRig = xrOrigin.transform.Find("Camera Offset/Main Camera");
        leftHandRig = xrOrigin.transform.Find("Camera Offset/LeftHand Controller");
        rightHandRig = xrOrigin.transform.Find("Camera Offset/RightHand Controller");
        photonView = GetComponent<PhotonView>();
       // cubePrefab.SetActive(true);
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

/*
lollllllllllllllllllllll

public class VRPlayerController : MonoBehaviourPunCallbacks
{
    private const byte InteractionEventCode = 1;

    public GameObject interactionIndicator;

    private PhotonView photonView;
    private bool canInteract = true;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canInteract && other.CompareTag("Player"))
        {
            PlayerController otherPlayer = other.GetComponent<PlayerController>();
            if (otherPlayer != null && photonView.IsMine)
            {
                // Call the Interact method for the other player using Photon's RaiseEvent method
                byte[] data = new byte[] { (byte)photonView.ViewID };
                PhotonNetwork.RaiseEvent(InteractionEventCode, data, new RaiseEventOptions { TargetActors = new int[] { otherPlayer.photonView.OwnerActorNr } }, SendOptions.SendReliable);
                
                // Set canInteract to false to prevent multiple interactions in quick succession
                canInteract = false;
                Invoke("ResetInteraction", 1f);
            }
        }
    }

    private void ResetInteraction()
    {
        canInteract = true;
    }

    // Handle the InteractionEventCode event when it is received by another player
    private void OnEvent(byte eventCode, object content, int senderId)
    {
        if (eventCode == InteractionEventCode)
        {
            byte[] data = (byte[])content;
            int playerId = (int)data[0];
            PlayerController player = PhotonView.Find(playerId).GetComponent<PlayerController>();
            if (player != null)
            {
                // Show an interaction indicator to the player who initiated the interaction
                if (photonView.IsMine)
                {
                    Instantiate(interactionIndicator, transform.position, transform.rotation, transform);
                }

                // Handle the interaction for the other player
                player.Interact(this);
            }
        }
    }

    // Subscribe to the OnEvent method when the player is created
    public override void OnJoinedRoom()
    {
        PhotonNetwork.NetworkingClient.EventReceived += OnEvent;
    }

    // Unsubscribe from the OnEvent method when the player is destroyed
    public override void OnLeftRoom()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= OnEvent;
    }
}
*/
