using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Torch : MonoBehaviour
{
    public Material material;
     
     //public GameObject Cube2;


    private Light spotLight;
    private const float TO_RADIAN = (3.1415f / 180.0f);
	
    void Start() {

         //TryInitialize();
        spotLight = GetComponent<Light>();
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

	void Update ()
    {
        material.SetVector("_LightPosition",  spotLight.transform.position);
        material.SetVector("_LightDirection", -spotLight.transform.forward);
        material.SetFloat ("_LightAngle", spotLight.spotAngle * TO_RADIAN);

        //  if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        // {
        //     handAnimator.SetFloat("Trigger", triggerValue);
        // }
        // else
        // {
        //     handAnimator.SetFloat("Trigger", 0);
        // }

    }
}
