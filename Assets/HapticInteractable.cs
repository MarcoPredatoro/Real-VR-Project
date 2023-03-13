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
        if (collision.gameObject.name == "Person(1)")
        {
            targetDevice.SendHapticImpulse(0, hapticIntensity, hapticDuration);
        }
    }



    // void TryInitialize()
    // {
    //     List<InputDevice> devices = new List<InputDevice>();

    //     InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
    //     if (devices.Count > 0)
    //     {
    //         targetDevice = devices[0];
    //     }
    // }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.name == "Polo")
    //     {
    //         targetDevice.SendHapticImpulse(0, hapticIntensity, hapticDuration);
    //     }
    // }


    // to check if the trigger is pressed and if it is, make the polos appear
    // void OnTriggerEnter()
    // {
    //     if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
    //     {
    //         if(triggerValue > 0.1f)
    //         {
    //             Debug.Log("Trigger pressed");
    //             //GetComponent<MeshRenderer>().enabled = true;
    //             GameObject.Find("Polo").GetComponent<PoloViewController>().StartCoroutine(makePoloAppear());
               
    //         }
    //     }
    // }



}
