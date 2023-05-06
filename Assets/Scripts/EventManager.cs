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
    private const byte GAME_COMPLETE_EVENT = 7;
    private const byte GAME_START = 8;

    //public GameObject tree;

    // public Image whiteScreen;
    // public float duration = 3f;

    //public int points;
    //public Text pointsText;
    public Text flashed;
    public Text eggStolen;
    

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
    [SerializeField]
    private Timer timer;

    // public float collisionCooldown = 3f;
    // private bool canSendCollision = true;


    // Start is called before the first frame update
    void Start()
    {
        //whiteScreen.enabled = false;
        flashed = GameObject.Find("FlashText").GetComponent<Text>();
        eggStolen = GameObject.Find("PoloEggText").GetComponent<Text>();
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
            eggStolen.text = "EGG STOLEN!";
            StartCoroutine(DisableEggStolen());
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
            flashed.text = "YOU'VE BEEN BLINDED";
            StartCoroutine(DisableFlashedText());
            flashBang.InhibitVision();
        }
        else if (photonEvent.Code == DECOY_EVENT)
        {
            //test.text = "Decoy Event Received";
            //GameObject.Find("Network Manager").GetComponent<Instantiation>().CreateLots();
            decoyPolo.CreateLots();
        }
        else if (photonEvent.Code == GAME_COMPLETE_EVENT)
        {
            timer.EndGame();
        }
        else if (photonEvent.Code == GAME_START)
        {

            timer.ResetTimer();
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

     public int returnPoints()
    {
        return points;
    }


    public void SendMarcoCollision()
    {
        Debug.Log("sending collision");
        RaiseEventOptions options = RaiseEventOptions.Default;
        options.Receivers = ReceiverGroup.All;
        PhotonNetwork.RaiseEvent(MARCO_STAB_EVENT, 1, options, SendOptions.SendReliable);
        // StartCoroutine(CollisionCooldown());
        //test.text = "Marco Event Sent";
        //tree.SetActive(false);
    }

    private IEnumerator DisableFlashedText()
    {
        yield return new WaitForSeconds(3f);
        flashed.text = " ";
    }

     private IEnumerator DisableEggStolen()
    {
        yield return new WaitForSeconds(2f);
        eggStolen.text = " ";
    }


//     private IEnumerator CollisionCooldown()
//     {
//         canSendCollision = false;
//         yield return new WaitForSeconds(collisionCooldown);
//         canSendCollision = true;
//     }
 }