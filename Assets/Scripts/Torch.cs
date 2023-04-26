using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;



public class Torch : MonoBehaviour
{
    public Material material;
    public Material PoloMatArmour;
    public Material PoloTank;
    public Material PoloBodySuit;


    public InputDeviceCharacteristics controllerCharacteristics;    
    private InputDevice targetDevice;
    private Light spotLight;
    private const float TO_RADIAN = (3.1415f / 180.0f);
    private float maxSpotAngle = 50f;
    private float minSpotAngle = 0f;
    private float spotAngleDecreaseRate = 15f;
    private float spotAngleIncreaseRate = 40f;

    public Material torchBar;
    public Material clawTorch;
    public Image torchBarImage;
    private Vector2 size;


	
    void Start() {

         TryInitialize();

          spotLight = GetComponent<Light>();
          spotLight.enabled = false;
          spotLight.spotAngle = maxSpotAngle;

          Rect t = torchBarImage.transform.GetComponent<RectTransform>().rect;
          size = new Vector2(t.width, t.height);

        
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
        if(triggerValue > 0.1f){
          
                spotLight.enabled = true;
                spotLight.spotAngle = Mathf.Max(minSpotAngle, spotLight.spotAngle - spotAngleDecreaseRate * Time.deltaTime);
            }
            else{

                spotLight.enabled = false;
                spotLight.spotAngle = Mathf.Min(maxSpotAngle, spotLight.spotAngle + spotAngleIncreaseRate * Time.deltaTime);
              
        }
        }
       
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

        PoloMatArmour.SetVector("_LightPosition",  spotLight.transform.position);
        PoloMatArmour.SetFloat("_LightAngle", spotLight.spotAngle * TO_RADIAN);

        if(spotLight.enabled){
            PoloMatArmour.SetVector("_LightDirection", -spotLight.transform.forward);
        }
        else{
            PoloMatArmour.SetVector("_LightDirection", spotLight.transform.forward);
        }

        PoloTank.SetVector("_LightPosition",  spotLight.transform.position);
        PoloTank.SetFloat("_LightAngle", spotLight.spotAngle * TO_RADIAN);

        if(spotLight.enabled){
            PoloTank.SetVector("_LightDirection", -spotLight.transform.forward);
        }
        else{
            PoloTank.SetVector("_LightDirection", spotLight.transform.forward);
        }

        PoloBodySuit.SetVector("_LightPosition",  spotLight.transform.position);
        PoloBodySuit.SetFloat("_LightAngle", spotLight.spotAngle * TO_RADIAN);

        if(spotLight.enabled){
            PoloBodySuit.SetVector("_LightDirection", -spotLight.transform.forward);
        }
        else{
            PoloBodySuit.SetVector("_LightDirection", spotLight.transform.forward);
        }

        if(!targetDevice.isValid)
        {
            
            TryInitialize();
        }
        else
        {
            UpdateHandAnimation();
        }

        updateTorchBar();
    }


    void updateTorchBar() 
    {
        float p = 1.0f - ((spotLight.spotAngle - minSpotAngle) / (maxSpotAngle - minSpotAngle));
        // Debug.Log(p);
        torchBar.SetFloat("_Points", p);
        clawTorch.SetFloat("_Points", p);
    }

    

}
