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
        
        
    }

    private void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.name == "polo-with-bones" || collision.gameObject.name == "Polo2")
        {
            targetDevice.SendHapticImpulse(0, hapticIntensity, hapticDuration);
            
            SendCollisionEvent();
              
        }
    }



    private void SendCollisionEvent()
    {
        
        GameObject.Find("Canvas/Image/Points").GetComponent<EventManager>().SendMarcoCollision();
    }


}
