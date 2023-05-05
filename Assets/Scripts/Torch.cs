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
    private float spotAngleDecreaseRate = 7f;
    private float spotAngleIncreaseRate = 40f;

    public Material torchBar;
    public Material clawTorch;
    public Image torchBarImage;
    public bool justPressed = true;
    private Vector2 size;

    private float cooldownTimer = 0f;
    private float cooldownDuration = 1f;


	
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
            if(cooldownTimer<= 0 )
            {
                if(triggerValue > 0.6f && justPressed)
                {
                spotLight.enabled = true;
                // spotLight.spotAngle = Mathf.Max(minSpotAngle, spotLight.spotAngle - spotAngleDecreaseRate * Time.deltaTime);
                cooldownTimer=cooldownDuration;
                justPressed = false;
                
                }
            }

        
            else if (triggerValue <= 0.6f)
            {
                spotLight.enabled = false;
                // spotLight.spotAngle = Mathf.Min(maxSpotAngle, spotLight.spotAngle + spotAngleIncreaseRate * Time.deltaTime);
                // StartCoroutine(PressCooldown());
            }


            if(spotLight.enabled){
            spotLight.spotAngle = Mathf.Max(minSpotAngle, spotLight.spotAngle - spotAngleDecreaseRate * Time.deltaTime);
            }
            else{
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

        if(cooldownTimer > 0){

            cooldownTimer -= Time.deltaTime;
        }
        else{
            justPressed = true;
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

     private IEnumerator PressCooldown()
    {
        justPressed = false;
        yield return new WaitForSeconds(2f);
        justPressed = true;
    }


    void updateTorchBar() 
    {
        float p = ((spotLight.spotAngle - minSpotAngle) / (maxSpotAngle - minSpotAngle) ) ;
        // Debug.Log(p);
        torchBar.SetFloat("_Torch", p);
        clawTorch.SetFloat("_Torch", p);
    }

    

}
