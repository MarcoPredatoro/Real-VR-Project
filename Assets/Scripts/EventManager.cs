using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine.UI;
using System;

public class EventManager : MonoBehaviourPun
{
    private const byte RFID_POINTS_EVENT = 1;
    private const byte MARCO_STAB_EVENT = 2;
    private const byte RESET_POINTS_EVENT = 3;
    private const byte BLIND_EVENT = 4;
    private const byte DECOY_EVENT = 5;

    //public GameObject tree;

    // public Image whiteScreen;
    // public float duration = 3f;

    //public int points;
    //public Text pointsText;
    //public Text test;
    

    public float threshold = 50;
    public int points;
    public Material pointsBar;
    public Image pointer;
    private Vector2 size;

    private float maxPoints = 100;
    private float minPoints = -100;

    [SerializeField]
    private FlashBang flashBang;

    [SerializeField]
    private Instantiation decoyPolo;

    // public float collisionCooldown = 3f;
    // private bool canSendCollision = true;


    // Start is called before the first frame update
    void Start()
    {
        //whiteScreen.enabled = false;
        //test = GameObject.Find("Text2").GetComponent<Text>();
        Rect t = pointer.transform.parent.GetComponent<RectTransform>().rect;
        size = new Vector2(t.width, t.height);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += OnEvent;
    }
    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= OnEvent;
    }

    private void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == RFID_POINTS_EVENT)
        {
            int value = (int)photonEvent.CustomData;
            //int value = (int)data[0];
            updatePoints(value);
        }
        else if (photonEvent.Code == MARCO_STAB_EVENT)
        {
            int value = (int)photonEvent.CustomData;
            //int value = (int)data[0];
            updatePoints(-value);

        }
        else if (photonEvent.Code == RESET_POINTS_EVENT)
        {
            points = 0;
        // pointsText.text = "Points: " + points.ToString();
            minPoints = -100;
            maxPoints = 100;
            updatePointsBar();
        }
        else if (photonEvent.Code == BLIND_EVENT)
        {
            //GameObject.Find("WhiteScreen/Canvas/Image").GetComponent<FlashBang>().StartCoroutine(FlashWhiteScreen());
            //test.text = "Blind Event Received";
            //GameObject.Find("Network Manager").GetComponent<FlashBangGPT>().InhibitVision();
            flashBang.InhibitVision();
        }
        else if (photonEvent.Code == DECOY_EVENT)
        {
            //test.text = "Decoy Event Received";
            //GameObject.Find("Network Manager").GetComponent<Instantiation>().CreateLots();
            decoyPolo.CreateLots();
        }
    }

    public void updatePoints(int value) {
        points += value;
        // pointsText.text = points.ToString();
        updatePointsBar();
    }

    void updatePointsBar() {
        minPoints = Mathf.Min(minPoints, points);
        maxPoints = Mathf.Max(maxPoints, points);
        
        float p = 1.0f - ((points - minPoints) / (maxPoints - minPoints));
        // Debug.Log(p);
        pointsBar.SetFloat("_Points", p);
        var position = pointer.GetComponent<RectTransform>().localPosition;
        pointer.GetComponent<RectTransform>().localPosition = new Vector3(size.x * p - (size.x/2.0f), position.y,position.z);
    }

    // IEnumerator<WaitForSeconds> FlashWhiteScreen()
    // {
    //     whiteScreen.enabled = true;
    //     //audioSource.Play();
    //     yield return new WaitForSeconds(duration);
    //     whiteScreen.enabled = false;
    // }


    public void SendMarcoCollision()
    {
   

        Debug.Log("sending collision");
        RaiseEventOptions options = RaiseEventOptions.Default;
        options.Receivers = ReceiverGroup.All;
        PhotonNetwork.RaiseEvent(MARCO_STAB_EVENT, 2, options, SendOptions.SendReliable);
        // StartCoroutine(CollisionCooldown());
        //test.text = "Marco Event Sent";
        //tree.SetActive(false);
        
        
    }

//     private IEnumerator CollisionCooldown()
//     {
//         canSendCollision = false;
//         yield return new WaitForSeconds(collisionCooldown);
//         canSendCollision = true;
//     }
 }