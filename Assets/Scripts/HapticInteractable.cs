using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class HapticInteractable : MonoBehaviour
{
    public float hapticIntensity;
    public float hapticDuration;
    public InputDeviceCharacteristics controllerCharacteristics;    
    private InputDevice targetDevice;
    public GameObject Sphere;
    public UnityEngine.UI.Image pointsImage;
    //private bool hasCollided = false;
    // Start is called before the first frame update
    void Start()
    {
    
        TryInitialize();
        
    }

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if (hasCollided)
        // {
        //     SendCollisionEvent();
        //     hasCollided = false;
        // }
        
    }

    private void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.name == "Polo" || collision.gameObject.name == "Polo2")
        {
            targetDevice.SendHapticImpulse(0, hapticIntensity, hapticDuration);
            //marcoCollision();
            // GameObject.Find("tree").SetActive(false);
            //GameObject.Find("Canvas/Image/Points").GetComponent<EventManager>().SendMarcoCollision();
            // hasCollided = true;
            SendCollisionEvent();
              
        }
    }

    // private void FixedUpdate()
    // {
    //     if (hasCollided)
    //     {
    //         SendCollisionEvent();
    //         hasCollided = false;
    //     }
    // }

    private void SendCollisionEvent()
    {
        
        GameObject.Find("Canvas/Image/Points").GetComponent<EventManager>().SendMarcoCollision();
    }

    // private bool stab = false;
    // public void marcoCollision()
    // {
    //     if (!stab)
    //     {
    //         stab = true;
    //         pointsImage.color = new Color(255, 0, 0);
    //         Sphere.SetActive(false);
    //         // pointsImage.material = pointsMaterial;
    //         GameObject.Find("Canvas/Image/Points").GetComponent<EventManager>().SendMarcoCollision();
    //         //GameObject.Find("Canvas/Image/Text1").GetComponent<EventManager>().SendMarcoCollision();
    //         StartCoroutine(turnBacktoWhite());
    //     }
    // }

    // IEnumerator<WaitForSeconds> turnBacktoWhite() {
    //     yield return new WaitForSeconds(5);
    //     // pointsImage.material = reset;
    //     pointsImage.color = new Color(255,255,255);
    //     stab = false;
    // }

     


    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.name == "Polo" || collision.gameObject.name == "Polo2")
    //     {
    //         targetDevice.SendHapticImpulse(0, hapticIntensity, hapticDuration);
    //         //GameObject.Find("tree").SetActive(false);
    //         //GameObject.Find("Marco").GetComponent<NetworkPlayer>().marcoCollision();
    //     }
    // }





}
