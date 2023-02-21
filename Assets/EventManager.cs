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

    public int points;
    public Text pointsText;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    public void updatePoints(int value) {
        points += value;
        pointsText.text = points.ToString();
    }
}