using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class Torch : MonoBehaviour
{
    public Material material;

    public InputDeviceCharacteristics controllerCharacteristics;    
     private InputDevice targetDevice;
     //public GameObject Cube2;
    private Light spotLight;

    // private float isPressed = 1.0f;
    private const float TO_RADIAN = (3.1415f / 180.0f);
	
    void Start() {

         TryInitialize();

          spotLight = GetComponent<Light>();
          spotLight.enabled = false;
          
        //material= GameObject.Find("Cube").GetComponent<Renderer>().material;

        //Cube2.SetActive(false);

        // if (spotLight != null){
        //     material.color = new Color(255, 0, 255);
        //     //Cube2.SetActive(false);
            
        // }
        // else{

        //     material.color = new Color(255, 255, 0);
        // }
        
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

     void UpdateHandAnimation()
    {
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            // handAnimator.SetFloat("Trigger", triggerValue);
            if(triggerValue > 0.1f ){
          
                spotLight.enabled = true;
            }
            else{
            spotLight.enabled = false;
            }
              
        }
       

        //use below code for grip if needed 
        // if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        // {
        //     handAnimator.SetFloat("Grip", gripValue);
        // }
        // else
        // {
        //     handAnimator.SetFloat("Grip", 0);
        // }
    }

	void Update ()
    {
        material.SetVector("_LightPosition",  spotLight.transform.position);
        material.SetFloat ("_LightAngle", spotLight.spotAngle * TO_RADIAN);
        
        if(spotLight.enabled){
            material.SetVector("_LightDirection", -spotLight.transform.forward);
        }
        else{
            material.SetVector("_LightDirection", spotLight.transform.forward);
        }
        if(!targetDevice.isValid)
        {
            
            TryInitialize();
        }
        else
        {
            UpdateHandAnimation();
        }

    }
}
